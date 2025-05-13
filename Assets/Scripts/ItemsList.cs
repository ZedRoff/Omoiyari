using System.Collections.Generic;
using UnityEngine;

public class ItemsList : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Sprite keySprite;
    public Sprite becherSprite;
    public Sprite defaultSprite;
    public Sprite bookSprite;
    public Dictionary<string, Item> items;
    public Sprite purpleSprite;
    void Start()
    {
       
        items = new Dictionary<string, Item>();
        items.Add("Clé", new Item("Clé", "Une simple clé", keySprite, true)); // fait

        items.Add("Cu504", new Item("Cu504", "Un composé chimique ionique", becherSprite, true)); // fait
        items.Add("NAH5O3", new Item("NAH5O3", "Un sel issu de la neutralisation partielle de l'acide sulfurique", becherSprite, true)); // fait (bad)
        items.Add("NAHGO3", new Item("NAHGO3", "Un composé inorganique", becherSprite, true));
        items.Add("aOHN", new Item("aOHN", "Une solution transparente encore plus corrosive qu'à l'état pur en raison de son aspect mouillant, qui augmente l'action et le contact avec la peau.", becherSprite, true));
        items.Add("Cu2O", new Item("Cu2O", "Un composé de l'oxygène et du cuivre.", becherSprite, true)); // Cu2O

        items.Add("Book", new Item("Book", "Un livre de chimie", bookSprite, true));
        items.Add("Bag", new Item("Bag", "Votre inventaire", defaultSprite, false));


        items.Add("PurpleSquare", new Item("PurpleSquare", "Carré violet", purpleSprite, true));
        items.Add("YellowPara", new Item("YellowPara", "Paralèllogramme jaune", purpleSprite, true));
        items.Add("BlueSmallTriangle", new Item("BlueSmallTriangle", "Petit triangle bleu", purpleSprite, true));
        items.Add("BlueBigTriangle", new Item("BlueBigTriangle", "Grand triangle bleu", purpleSprite, true));

        items.Add("RedMediumTriangle", new Item("RedMediumTriangle", "Moyen triangle rouge", purpleSprite, true));
        items.Add("GreenSmallTriangle", new Item("GreenSmallTriangle", "Petit triangle vert", purpleSprite, true));
        items.Add("VioletBigTriangle", new Item("VioletBigTriangle", "Grand triangle violet", purpleSprite, true));

        items.Add("Aucun", new Item("Aucun", "aucun item", defaultSprite, false));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
