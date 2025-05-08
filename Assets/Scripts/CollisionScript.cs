using UnityEngine;

public class CollisionScript : MonoBehaviour
{
      public StateScript stateScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         stateScript = GameObject.Find("State Manager").GetComponent<StateScript>();   
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")) {
            if(gameObject.CompareTag("Start Collider")) {
                stateScript.state = State.StartDialog;
                Destroy(other);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
