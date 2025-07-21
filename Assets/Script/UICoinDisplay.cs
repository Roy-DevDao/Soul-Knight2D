using UnityEngine;
using TMPro;

public class UICoinDisplay : MonoBehaviour
{
    public static UICoinDisplay Instance;

    public TextMeshProUGUI coinText; // Assign in Inspector
    private int coinCount = 0;

    private void Awake()
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
    }

    public int GetCoinCount()
    {
        return coinCount;
    }
}
