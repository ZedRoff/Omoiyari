using UnityEngine;

public class MouseLookMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float mouseSensitivity = 25f;
    public float acceleration = 10f;
    public Transform playerBody; // Usually this is the same GameObject

    float rotationY = 0f;
    float rotationX = 0f;

    public TextScript textScript;
    void Start()
    {
        textScript = GameObject.Find("Text Manager").GetComponent<TextScript>();
    }
    void Update()
    {
        if (textScript.IsInDialog()) return;
        HandleShift();
        MovePlayer();
        RotatePlayerWithMouse();
    }
    void HandleShift()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = 15f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = 5f;
        }
    }

    void MovePlayer()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical"); 
     
        Vector3 move = transform.forward * v + transform.right * h;
        transform.position -= move.normalized * moveSpeed * Time.deltaTime;
    }

    void RotatePlayerWithMouse()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        rotationY += mouseX;

        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        rotationY += mouseY;
        playerBody.rotation = Quaternion.Euler(rotationX, rotationY, 0f);
        
       
    }
}
