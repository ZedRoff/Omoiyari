using UnityEngine;

public class Bottle : MonoBehaviour
{
    public string chemicalName; // Exemple : "sulfate_cuivre" ou "hydroxyde_sodium"

    public void OnSelected()
    {
        GameManager.Instance.AddChemical(chemicalName);
        Debug.Log("Flacon ajouté : " + chemicalName);
    }
}
