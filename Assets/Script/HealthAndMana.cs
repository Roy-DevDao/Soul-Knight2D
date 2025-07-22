using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthAndMana : MonoBehaviour
{
    public static HealthAndMana healthAndMana;
    public Image fillHealthBar;
    public Image fillManaBar;
    public TMP_Text healthText;
    public TMP_Text manaText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthText.text = "100/100"; 
        manaText.text = "50/50";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Awake()
    {
        if (healthAndMana == null) healthAndMana = this;
        else Destroy(gameObject);
    }
    public void UpdateHealthBar(int currentValue, int maxValue)
    {
        fillHealthBar.fillAmount = (float)currentValue / maxValue;
        healthText.text = $"{currentValue}/{maxValue}";
    }
}
