using Unity.Properties;
using UnityEngine;

public class GameScript : MonoBehaviour
{

    public StateScript stateScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stateScript = GameObject.Find("State Manager").GetComponent<StateScript>();   
    }
    

    // Update is called once per frame
    void Update()
    {
     
    }
}



