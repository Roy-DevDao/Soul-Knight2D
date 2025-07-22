using UnityEngine;

public class CoinSoundManager : MonoBehaviour
{
    public static CoinSoundManager Instance;

    public AudioClip coinSound;
    private AudioSource audioSource;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
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
