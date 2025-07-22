using UnityEngine;
using TMPro;

public class UICoinDisplay : MonoBehaviour
{
    public static UICoinDisplay Instance;

    public TextMeshProUGUI coinText; // Assign in Inspector
    public int coinCount = 0;

    public void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AddCoin(int amount)
    {
        coinCount += amount;
        coinText.text = "x " + coinCount;
                SoundManager.Instance.PlayCoinSound();

    }

    public int GetCoinCount()
    {
        return coinCount;
    }
}
