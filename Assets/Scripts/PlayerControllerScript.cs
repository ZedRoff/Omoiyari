using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{

    public float moveSpeed = 5.0f;
    public float rotationSpeed = 720.0f;
  
    private CharacterController controller;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }
    public void HandleMovement() {
        
    }
}
