using UnityEngine;
using UnityEngine.Rendering;

public class CollisionScript : MonoBehaviour
{
      public StateScript stateScript;
      public ActionsScript actionsScript;
    public GameScript gameScript;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         stateScript = GameObject.Find("State Manager").GetComponent<StateScript>();
        gameScript = GameObject.Find("Game Manager").GetComponent<GameScript>();
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
    private void OnTriggerExit(Collider other)
    {
        if (gameObject.name == "ChemistryCollider" && !gameScript.hasFinishedChemistry)
        {
            stateScript.state = State.StartChemistryDialog;
            gameScript.timerScript.StartTimer(5 * 60);
        }
        if(gameObject.name == "PlayGroundCollider" && !gameScript.hasFinishedPlayground)
        {

            if (!gameScript.filter.playGroundStarted)
            {
                gameScript.filter.playGroundStarted = true;
                stateScript.state = State.StartPlayGroundDialog;
                gameScript.timerScript.StartTimer(10 * 60);
                gameScript.filter.ActivateDaltonism();
            } else
            {
                if (gameScript.filter.postProActivated)
                {

                    gameScript.filter.DeActivateDaltonism();
                }
                else
                {

                    gameScript.filter.ActivateDaltonism();
                }
            }

               
                
        }
        {

        }
    }
    // Update is called once per frame
    void Update()
    {
      
    }
}
