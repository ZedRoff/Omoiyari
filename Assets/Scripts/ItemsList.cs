using System.Collections.Generic;
using UnityEngine;

public class ItemsList : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Sprite keySprite;
    public Sprite becherSprite;
    public Sprite defaultSprite;
       public Dictionary<string, Item> items;
    void Start()
    {
        items = new Dictionary<string, Item>();
        items.Add("Clé", new Item("Clé", "Une simple clé", keySprite, true));
        items.Add("Becher", new Item("Becher", "Un becher qui peut accueillir une substance", becherSprite, true));
        items.Add("Aucun", new Item("Aucun", "aucun item", defaultSprite, false));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
