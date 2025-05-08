using System.Collections.Generic;
using UnityEngine;

public class ItemsList : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Sprite keySprite;
       public Dictionary<string, Item> items;
    void Start()
    {
        items = new Dictionary<string, Item>();
        items.Add("key1", new Item("Clé", "Une simple clé", keySprite));
        items.Add("key2", new Item("Clé Spéciale", "Une clé très très spéciale", keySprite));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
