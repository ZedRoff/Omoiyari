
using UnityEngine;
using UnityEngine.UI;

public class CrossHairScript : MonoBehaviour
{
   
    public float rayDistance = 30.0f;
    public Camera camView;
    public Sprite EKeyImage;
    public Sprite defaultImage;
    public Image crossHair;
    public InventoryScript inventoryScript;
    public ItemsList itemsList;
    private float defaultSize = 3.0f;
    private float scaledSize = 12.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     
        inventoryScript = GameObject.Find("Inventory Manager").GetComponent<InventoryScript>();
        itemsList = GameObject.Find("Items Manager").GetComponent<ItemsList>();
    }

    // Update is called once per frame
    void Update()
    {
     
        Ray ray = new Ray(camView.transform.position, camView.transform.forward);
        RaycastHit hit;
         Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.red);

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            if (hit.collider.CompareTag("Collectible"))
            {
                if(Input.GetKeyUp(KeyCode.E)) {
                      string itemName = hit.collider.gameObject.name;
            if(itemsList.items.ContainsKey(itemName)) {
                Item item = itemsList.items[itemName];
                inventoryScript.player.inventory.AddItem(item);
                Debug.Log("Picked up: " + item.itemName);
                Destroy(hit.collider.gameObject);
            }
                }
                crossHair.sprite = EKeyImage;
                crossHair.rectTransform.localScale = new Vector3(scaledSize, scaledSize, scaledSize);
              
               
            }
            else
            {  
              crossHair.sprite = defaultImage;
              crossHair.rectTransform.localScale = new Vector3(defaultSize, defaultSize, defaultSize);
               
            }
        }
        else
        {
             crossHair.sprite = defaultImage;
             crossHair.rectTransform.sizeDelta = new Vector3(defaultSize, defaultSize, defaultSize);
        }
    }
}
