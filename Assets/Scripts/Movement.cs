using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] GameObject startText;

    [SerializeField]
    InputAction thrust;
    [SerializeField]
    InputAction rotate;
    [SerializeField]
    AudioClip mainEngine;
    Rigidbody rb;
    AudioSource audioSource;
    [SerializeField]
    ParticleSystem mainEngineParticles;
    [SerializeField]
    ParticleSystem leftEngineParticles;
    [SerializeField]
    ParticleSystem rightEngineParticles;


    [SerializeField]
    float _thrustForce=50f;
    private void OnEnable()
    {
        thrust.Enable();
        rotate.Enable();
    }
       
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      rb=GetComponent<Rigidbody>(); 
      audioSource=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ThrustForce();
        Rotation();

    }

    private void ThrustForce()
    {
        if (thrust.ReadValue<float>() > 0)
        {
            HideStartText();
            rb.AddRelativeForce(Vector3.up * _thrustForce);
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainEngine);
                mainEngineParticles.Play();
            }
          

        }
        else
        {
            audioSource.Stop();
            mainEngineParticles.Stop();
        }
    }
    private void Rotation()
    {
      float rotationInput= rotate.ReadValue<float>();
        if(rotationInput!=0)
            {
                rb.AddRelativeTorque(Vector3.back * rotationInput * 5);
                
            }
        if (rotationInput<0)
        { 
         rightEngineParticles.Play();
          
        }
        else
        {
            rightEngineParticles.Stop();
        }
        if (rotationInput>0)
        {
            leftEngineParticles.Play();
        }
        else
        {
            leftEngineParticles.Stop(); 
        }
    }
        void HideStartText()
    {
         if (startText) 
        {
        startText.SetActive(false);
        }
    }
    void Awake()
    {
        Application.targetFrameRate = 60;  // или -1 для без лимита, но с VSync
    }
    
}


