
using UnityEngine;

public class GameScript : MonoBehaviour
{


    public Player player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

 void Awake()
{
    player = new Player();
}
    void Start()
    {
       
    }
    public Player GetPlayer() {
        return player;
    }
    

    // Update is called once per frame
    void Update()
    {
     
    }
}



