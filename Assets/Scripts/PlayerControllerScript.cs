using Unity.Cinemachine;
using UnityEngine;

public class MouseLookMovement : MonoBehaviour
{
    private float moveSpeed = 2.5f;
    private float acceleration = 5.0f;

    public Rigidbody rb;

    public TextScript textScript;
    public bool isOnGround;
    public Transform cameraCine;
    public InventoryScript inventoryScript;
    public ItemsList itemsList;


    public float mouseSensitivity = 100f;
    public Transform playerBody;      // The object that should rotate horizontally (usually the player GameObject)
    public Transform cameraTransform; // The camera or the object that rotates vertically

    float xRotation = 0f;

    void Start()
    {
        textScript = GameObject.Find("Text Manager").GetComponent<TextScript>();
        inventoryScript = GameObject.Find("Inventory Manager").GetComponent<InventoryScript>();
        itemsList = GameObject.Find("Items Manager").GetComponent<ItemsList>();
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }
 
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground")) {
            isOnGround = true;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Collectible")) {
            string itemName = other.gameObject.name;
            if(itemsList.items.ContainsKey(itemName)) {
                Item item = itemsList.items[itemName];
                inventoryScript.player.inventory.AddItem(item);
                Debug.Log("Picked up: " + item.itemName);
                Destroy(other.gameObject);
            }
        }
    }
    void Update()
    {
        if (textScript.IsInDialog() || inventoryScript.isShowPanel) return;
       
        HandleShift();

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY; 
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); 

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); 
        gameObject.transform.Rotate(Vector3.up * mouseX); 
    }
 
      void FixedUpdate()
    {
         if (textScript.IsInDialog() || inventoryScript.isShowPanel) return;
        MovePlayer(); 
    }
    void HandleShift()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) moveSpeed = acceleration;
        if (Input.GetKeyUp(KeyCode.LeftShift)) moveSpeed = 2.5f;
    }

   
void MovePlayer()
{
    float horizontal = Input.GetAxis("Horizontal");
    float vertical = Input.GetAxis("Vertical");

    Vector3 move = (transform.right * horizontal + transform.forward * vertical).normalized * moveSpeed * Time.deltaTime;

    transform.position += move;
}

  
}
