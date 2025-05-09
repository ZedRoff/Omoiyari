
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{

    public GameObject pauseMenu;
    public bool isShowOptions;
    public GameObject optionsMenu;
    public Player player;
    public StateScript stateScript;
    public bool isShowPause;

    public GameObject playerObject;
    public Image holdPoint;
    public ItemsList itemsList;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

 void Awake()
{
    player = new Player();
    itemsList = GameObject.Find("Items Manager").GetComponent<ItemsList>();
}
    void Start()
    {
        stateScript = GameObject.Find("State Manager").GetComponent<StateScript>();
        pauseMenu = GameObject.Find("Pause Menu");
        optionsMenu = GameObject.Find("Option Menu");
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
        ChangeCurrentItem(itemsList.items["Aucun"]);





    }
  
    

    // Update is called once per frame
    void Update()
    {

        
     if(Input.GetKeyUp(KeyCode.Escape)) {
          if(isShowOptions) {
                CloseOptionsMenu();
            } else {
        if(isShowPause) {
            ClosePauseMenu();
          
        } else {
            if(stateScript.state == State.Play) {
            ShowPauseMenu();
            }
        }
            }
        
     }
    }

      public void ChangeCurrentItem(Item item) {
        player.currentItem = item;
         holdPoint.sprite = item.icon;
    }
    public void ChangeCurrentItemOnButtonClick(BaseEventData data) {
         PointerEventData pointerData = data as PointerEventData;
        GameObject clickedObject = pointerData.pointerPress;
     
        TextMeshProUGUI itemText = clickedObject.transform.Find("Name").GetComponent<TextMeshProUGUI>();
        string itemName = itemText.text;
    
        if(itemName.Length == 0) {
          itemName = "Aucun";
        }
    
      Item item = itemsList.items[itemName];
        ChangeCurrentItem(item);
        
    }
    public Player GetPlayer() {
        return player;
    }
    public void ShowPauseMenu() {
        isShowPause = true;
        stateScript.state = State.Pause;
        Cursor.lockState = CursorLockMode.None;
        pauseMenu.SetActive(true);
    }
    public void ClosePauseMenu() {
        isShowPause = false;
        stateScript.state = State.Play;
        Cursor.lockState = CursorLockMode.Locked;
            pauseMenu.SetActive(false);
    }


    public void ShowOptionsMenu() {
        isShowPause = false;
        isShowOptions = true;
        stateScript.state = State.Options;
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }
    public void CloseOptionsMenu() {
        isShowOptions = false;
        isShowPause = true;
        stateScript.state = State.Pause;
            optionsMenu.SetActive(false);
            pauseMenu.SetActive(true);

    }
}



