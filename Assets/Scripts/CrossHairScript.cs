using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class CrossHairScript : MonoBehaviour
{
   
    public float rayDistance = 30.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;
         Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.red);

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            if (hit.collider.CompareTag("Collectible"))
            {
                Debug.Log("passage ray");
            }
            else
            {
                Debug.Log("pas passage ray");
            }
        }
        else
        {
            
        }
    }
}
