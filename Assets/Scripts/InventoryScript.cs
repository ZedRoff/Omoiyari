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

       if (Input.GetKeyUp(KeyCode.Tab))
        {

            isShowPanel = !isShowPanel;

            if(isShowPanel) {
                stateScript.state = State.Inventory;

            } else {
                stateScript.state = State.Play;
            }

            if(isShowPanel) {
            
               for(int i=0;i<player.inventory.GetCount();i++) {
                Item currentItem = player.inventory.items[i];
                Transform slot = items.transform.GetChild(i);
                Image itemImage = slot.GetComponentInChildren<Image>();
                TextMeshProUGUI itemText = slot.GetComponentInChildren<TextMeshProUGUI>();
               
               itemImage.sprite = currentItem.icon;
               itemImage.enabled = true;
               itemText.text = currentItem.itemName;
               }
            }

            inventoryPanel.SetActive(isShowPanel);
        }
    }
}
