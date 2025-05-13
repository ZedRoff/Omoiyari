using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class InventoryScript : MonoBehaviour
{
    public Player player;
    public GameObject inventoryPanel;
    public bool isShowPanel;

    public GameObject items;
    public StateScript stateScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inventoryPanel.SetActive(false);
        player = GameObject.Find("Game Manager").GetComponent<GameScript>().GetPlayer();
        stateScript = GameObject.Find("State Manager").GetComponent<StateScript>();
      
    }

    // Update is called once per frame
    void Update()
    {

       if (Input.GetKeyUp(KeyCode.Tab) && player.inventory.HasItem("Bag"))
        {
         
            isShowPanel = !isShowPanel;

            if(isShowPanel) {
                stateScript.state = State.Inventory;
        Cursor.lockState = CursorLockMode.None;

            } else {
                stateScript.state = State.Play;
        Cursor.lockState = CursorLockMode.Locked;
            }

            if(isShowPanel) {
           
               for(int i=0;i<player.inventory.GetCount();i++) {
                Item currentItem = player.inventory.items[i];
                   //if (currentItem.itemName == "Bag") continue; // just in case
                Transform slot = items.transform.GetChild(i);
                Image itemImage = slot.GetComponentInChildren<Image>().GetComponentInChildren<Image>();
                TextMeshProUGUI itemText = slot.GetComponentInChildren<TextMeshProUGUI>();
               
               itemImage.sprite = currentItem.icon;
               itemImage.enabled = true;
                    itemImage.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
               itemText.text = currentItem.itemName;
               }
            }
            inventoryPanel.SetActive(isShowPanel);
        }
    }
}
