using Unity.Cinemachine;
using UnityEngine;

public class MouseLookMovement : MonoBehaviour
{
    private float moveSpeed = 10.0f;
    private float acceleration = 5.0f;

    public Rigidbody rb;

    public TextScript textScript;
    public bool isOnGround;
    public Transform cameraCine;

    public float mouseSensitivity = 200f;
    public Transform playerBody;      
    public Transform cameraTransform; 

    float xRotation = 0f;
    public StateScript stateScript; 
    public bool isMoving;
    public bool isRunning;
    void Start()
    {
        textScript = GameObject.Find("Text Manager").GetComponent<TextScript>();
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        stateScript = GameObject.Find("State Manager").GetComponent<StateScript>();
    }
 
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground")) {
            isOnGround = true;
        }
    }
  
    void Update()
    {
        if (stateScript.state != State.Play) return;
       
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
         if (stateScript.state != State.Play) return;
        MovePlayer(); 
    }
    void HandleShift()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            
            moveSpeed = acceleration;
            isRunning = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift)) {
            
            moveSpeed = 5.0f;
            isRunning = false;

        }
    }

   
void MovePlayer()
{
    float horizontal = Input.GetAxis("Horizontal");
    float vertical = Input.GetAxis("Vertical");
    isMoving = Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0;
Vector3 move = (transform.right * horizontal + transform.forward * vertical).normalized * moveSpeed;
rb.MovePosition(rb.position + move * Time.fixedDeltaTime);
}

  
}
