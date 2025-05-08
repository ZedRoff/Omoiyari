
using UnityEngine;

public class GameScript : MonoBehaviour
{

    public GameObject pauseMenu;
    public bool isShowOptions;
    public GameObject optionsMenu;
    public Player player;
    public StateScript stateScript;
    public bool isShowPause;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

 void Awake()
{
    player = new Player();
}
    void Start()
    {
        stateScript = GameObject.Find("State Manager").GetComponent<StateScript>();
    pauseMenu = GameObject.Find("Pause Menu");
    optionsMenu = GameObject.Find("Option Menu");
    pauseMenu.SetActive(false);
    optionsMenu.SetActive(false);
    }
    public Player GetPlayer() {
        return player;
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



