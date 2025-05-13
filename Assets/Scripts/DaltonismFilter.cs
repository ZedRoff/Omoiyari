using UnityEngine;

public class DaltonismFilter : MonoBehaviour
{
    public GameObject[] profiles; // Chaque GameObject a un composant Volume
    private int current = 0;
    private float timer = 0f;
    public float interval = 30f;
    public bool postProActivated;
    public bool playGroundStarted;

    void Start()
    {
        // Activer seulement le premier profil au départ
       // ActivateDaltonism();
    }
    public void ActivateDaltonism()
    {
        for (int i = 0; i < profiles.Length; i++)
        {
            profiles[i].SetActive(i == 0);
        }
        postProActivated = true;
    }
    public void DeActivateDaltonism()
    {
        for (int i = 0; i < profiles.Length; i++)
        {
            profiles[i].SetActive(false);
        }
        postProActivated = false;
    }
    void Update()
    {
       /* timer += Time.deltaTime;
        if (timer >= interval)
        {
            // Désactiver tous les profils
            foreach (GameObject obj in profiles)
                obj.SetActive(false);

            // Activer le suivant
            current = (current + 1) % profiles.Length;
            profiles[current].SetActive(true);

            timer = 0f;
        }*/
    }
}
