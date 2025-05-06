using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("NomDeTaSceneJeu");
    }

    public void Options()
    {
        // À ouvrir via un panneau UI
        Debug.Log("Menu options");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitter le jeu");
    }
}
