using UnityEngine;

public class StateScript : MonoBehaviour
{
    public State state {get; set;}
        public TextScript textScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        state = State.PreGame;
         textScript = GameObject.Find("Text Manager").GetComponent<TextScript>();  
    }

    // Update is called once per frame
    void Update()
    {
        switch (state) 
        {
            case State.Start:
                string[][] texts = new string[][]{
                new string[] { "Ford", "Tu te demandes où tu es, n'est-ce pas ?" },
                new string[] { "Ford", "Je m'appelle Ford, et tu es dans ma simulation" },
                new string[] { "Ford", "Ton objectif, me débrancher afin d'en sortir"},
                new string[] { "Ford", "Bonne chance"}
            
            };
            textScript.StartDialog(texts);
            state = State.WaitForTuto;
            break;
          
            case State.Pending:
                Debug.Log("pending state");
            break;
         
        }
    }
}
