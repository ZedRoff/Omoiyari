using UnityEngine;

public class Item
{
    public string itemName;
    public string itemDescription;
    public Sprite icon;
    
    public Item(string name, string description, Sprite sprite) {
        itemName = name;
        itemDescription = description;
        icon = sprite;
    }
    
}
