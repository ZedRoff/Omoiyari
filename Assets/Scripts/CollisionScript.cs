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
        if(other.CompareTag("Player") && stateScript.state == State.PreGame) {
            if(gameObject.CompareTag("Start Collider")) {
                stateScript.state = State.Start;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
