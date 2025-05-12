using UnityEngine;

public class TangramPiece : MonoBehaviour
{
    public bool isCollected = false;
    public AudioClip collectSound; // Son à jouer lors de la collecte
    private AudioSource audioSource;

    private void Start()
    {
        // Récupère un AudioSource sur l'objet
        audioSource = GetComponent<AudioSource>();
   
    }
    // Méthode pour marquer la pièce comme collectée
    public void Collect()
    {
        isCollected = true;
        audioSource.PlayOneShot(collectSound);
        gameObject.SetActive(false); // Normalement pas besoin car convertit en item cache la pièce une fois collectée
    }
}