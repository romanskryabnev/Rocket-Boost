using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;
    AudioSource audioSource;

    private void Awake()
    {
        // Singleton — не даём создать второй экземпляр
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }
}
