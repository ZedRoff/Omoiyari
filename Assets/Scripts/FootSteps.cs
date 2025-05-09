using UnityEngine;

public class FootSteps : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public AudioSource audioSource;
    public float timer;
    public MouseLookMovement playerControllerScript;
    public float stepRate;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerControllerScript = GetComponent<MouseLookMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerControllerScript.isMoving) {
            if(playerControllerScript.isRunning) {
                stepRate = 0.35f;
            } else {
                stepRate = 0.5f;
            }
        timer += Time.deltaTime;
        if(timer >= stepRate) {
            PlayFootSteps();
            timer = 0;
        }
        }
        
    } 
    public void PlayFootSteps() {
        audioSource.Play();
    }
}
