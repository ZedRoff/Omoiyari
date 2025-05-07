using UnityEngine;

public class GameScript : MonoBehaviour
{
    public TextScript textScript;
    public int step = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textScript = GameObject.Find("Text Manager").GetComponent<TextScript>();        
    }

    // Update is called once per frame
    void Update()
    {
        string[][] texts = new string[][]{
            new string[] { "Ford", "Tu te demandes où tu es, n'est-ce pas ?" },
            new string[] { "Jordan", "Je m'appelle belcollin" }
        };
        textScript.StartDialog(texts);

    }
}



