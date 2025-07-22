using UnityEngine;
using TMPro;

public class UICoinDisplay : MonoBehaviour
{
    public static UICoinDisplay Instance;

    public TextMeshProUGUI coinText; 
    public  int coinCount = 0;

    private void Start()
    {
        coinCount = ParametersScript.point;
        coinText.text = "x " + coinCount;
    }

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
        CoinSoundManager.Instance.PlayCoinSound();

    }

    public int GetCoinCount()
    {
        return coinCount;
    }
}
