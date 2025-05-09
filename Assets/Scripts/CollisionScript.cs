using UnityEngine;

public class CollisionScript : MonoBehaviour
{
      public StateScript stateScript;
      public ActionsScript actionsScript;

 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         stateScript = GameObject.Find("State Manager").GetComponent<StateScript>();   
         actionsScript = GameObject.Find("Actions Manager").GetComponent<ActionsScript>(); 
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")) {
            if(gameObject.name == "StartCollider") {
                stateScript.state = State.StartDialog;
                Destroy(gameObject);
            }
            if(gameObject.name == "Quest1Collider") {
             
                    actionsScript.AddTask("Ouvrir la porte", false);
                    actionsScript.AddTask("Trouvez la clé", false);
                      Destroy(gameObject);
            }  
            if(gameObject.name == "FlushCollider") {
                    actionsScript.FlushTasks();
                      Destroy(gameObject);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
      
    }
}
