using UnityEngine;

public class BookInteract : MonoBehaviour
{
    [TextArea(3, 10)]
    public string bookContent;

    private void OnMouseDown()
    {
        BookPopupManager.instance.ShowPopup(bookContent);
    }
}
