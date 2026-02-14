using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject exitText;
    float delayBeforeExit = 3f;
    [SerializeField]
    AudioClip crashSound;
    [SerializeField]
    AudioClip finishSound;
    AudioSource audioSource;
    [SerializeField]
    ParticleSystem crashParticles;
    [SerializeField]
    ParticleSystem finishParticles;
    private void Start()
    {
        audioSource=GetComponent<AudioSource>();
         if (exitText != null)
        exitText.SetActive(false);
    }
    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "friendly":
                break;
            case "Finish":
                {  
                    StartFinishSequence();
                }
                break;
            case "ground":
                {
                    StartCrashSequence();
                }
                break;
        
        }
    }

    private void StartFinishSequence()
    {
        Invoke ("LoadNextScene",2f);
        GetComponent<Movement>().enabled=false;
        audioSource.PlayOneShot(finishSound);
        finishParticles.Play();
    }

    private void StartCrashSequence()
    {
       Invoke ("ReloadScene",2f);
       GetComponent<Movement>().enabled=false;
        audioSource.PlayOneShot(crashSound, 0.5f);
        crashParticles.Play();
    }

    void ReloadScene()
    {   int currentScene=SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    void LoadNextScene()
    {
        int currentScene=SceneManager.GetActiveScene().buildIndex;
        int nextScene=currentScene+1;
        if(nextScene==SceneManager.sceneCountInBuildSettings)
        {
            exitText.SetActive(true);
            Invoke(nameof(Application.Quit), 3f);
            return;
        }
        SceneManager.LoadScene(nextScene);
    }
    
}
