using UnityEngine;
using TMPro;
using System.Collections;

public class TextScript : MonoBehaviour
{
    public TextMeshProUGUI bulle;
    public GameObject boxBulle;
    public GameObject buttonX;

    private bool isTyping = false;
    private int dialogIndex = 0;

    string[][] texts = null;

    void Start()
    {
       boxBulle.SetActive(false);
       buttonX.SetActive(false);
      
    }
    public void StartDialog(string[][] pTexts)
    {
        texts = pTexts;
    }

    public bool IsInDialog()
    {
        Debug.Log(texts);
        return texts == null;
    }
    public bool IsTyping()
    {
        return isTyping;
    }
    IEnumerator TypeLine(string speaker, string line)
    {

        boxBulle.SetActive(true);
        isTyping = true;
        string fullText = $"<u>{speaker}</u> : ";
        bulle.text = fullText;

        foreach (char c in line)
        {
            fullText += c;
            bulle.text = fullText;
            yield return new WaitForSeconds(0.02f);
        }

        isTyping = false;
    }
    void CloseBulle()
    {
        StopAllCoroutines();
        isTyping = false;
        bulle.text = "";
        boxBulle.SetActive(false);
        buttonX.SetActive(false);
        dialogIndex = 0;
        texts = null;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("IsTyping" + isTyping);
        Debug.Log("Texts length" + texts.Length);
        if (Input.GetKeyUp(KeyCode.K) && !isTyping && texts.Length != 0)
        {
            if(dialogIndex < texts.Length)
            {
                StartCoroutine(TypeLine(texts[dialogIndex][0], texts[dialogIndex][1]));
                dialogIndex++;

            } else
            {
                CloseBulle();
            }
          
        }
  
    }
}
