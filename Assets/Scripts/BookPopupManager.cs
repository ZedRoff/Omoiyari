using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BookPopupManager : MonoBehaviour
{
    public GameObject popupPanel;
    public TextMeshProUGUI popupText;

    public static BookPopupManager instance;

    private void Awake()
    {
        instance = this;
        popupPanel.SetActive(false);
    }

    public void ShowPopup(string content)
    {
        popupText.text = content;
        popupPanel.SetActive(true);
    }

    public void HidePopup()
    {
        popupPanel.SetActive(false);
    }
}
