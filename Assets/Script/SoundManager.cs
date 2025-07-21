using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static SoundManager Instance;

    public AudioClip coinSound;
    private AudioSource audioSource;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Optional: persist between scenes
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayCoinSound()
    {
        if (coinSound != null)
        {
            Debug.Log("Playing coin sound from SoundManager");
            audioSource.PlayOneShot(coinSound);
        }
        else
        {
            Debug.LogWarning("Coin sound not assigned in SoundManager.");
        }
    }

}
