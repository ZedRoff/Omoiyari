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
        items.Add("Sulfate de cuivre", new Item("Sulfate de cuivre", "Un composé chimique ionique", becherSprite, true));
        items.Add("Bisulfite de sodium", new Item("Bisulfite de sodium", "Un sel issu de la neutralisation partielle de l'acide sulfurique", becherSprite, true));
        items.Add("Bicarbonate de sodium", new Item("Bicarbonate de sodium", "Un composé inorganique", becherSprite, true));
        items.Add("Hydroxyde de sodium", new Item("Hydroxyde de sodium", "Une solution transparente encore plus corrosive qu'à l'état pur en raison de son aspect mouillant, qui augmente l'action et le contact avec la peau.", becherSprite, true));
        items.Add("Aucun", new Item("Aucun", "aucun item", defaultSprite, false));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
