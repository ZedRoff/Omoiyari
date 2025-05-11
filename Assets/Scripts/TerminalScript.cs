using UnityEngine;
using TMPro;

public class TerminalScript : MonoBehaviour
{
    public TMP_InputField inputField;
    public TextMeshProUGUI feedbackText;
    //public QuizManagerCodeMode quizManager;

    public void SubmitCode()
    {
        string playerCode = inputField.text;
        string correctCode = quizManager.GetCode();

        if (playerCode == correctCode)
        {
            feedbackText.text = "Code correct ! Virus désactivé ✅";
            // TODO : jouer une animation ou une fin de jeu
        }
        else
        {
            feedbackText.text = "Code incorrect. Réessaie.";
        }
    }
}
