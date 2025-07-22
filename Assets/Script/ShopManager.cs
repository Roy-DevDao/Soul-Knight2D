using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
     public Button recoverHpButton;
     public Button recoverManaButton;

    public TextMeshProUGUI coinText;

     public int recoverHpCost = 5;
     public int playerHPRecover = 30;
    public int recoverManaCost = 5;
    public int playerManaRecover = 30;
    public UICoinDisplay uiCoinDisplay;
     public HealthAndMana healthAndMana;
     public PlayerHealth playerHealth;
    public PlayerMana playerMana;


    void Start()
     {

         if (recoverHpButton != null)
             recoverHpButton.onClick.AddListener(BuyHealth);

        if (recoverManaButton != null)
            recoverManaButton.onClick.AddListener(BuyMana);
    }

     void Update()
     {
         if (coinText != null)
         {
             coinText.text = "x " + UICoinDisplay.Instance.GetCoinCount();
         }
     }

     public void BuyHealth()
     {
         if (UICoinDisplay.Instance.GetCoinCount() >= recoverHpCost)
         {
             UICoinDisplay.Instance.coinCount -= recoverHpCost;
             healthAndMana.Heal(playerHealth.currentHealth, playerHPRecover);
             Debug.Log("Bought HP recovery!");
         }
         else
         {
             Debug.Log("Not enough coins!");
         }
     }
    public void BuyMana()
    {
        Debug.Log("currentMANA: " + playerMana.currentMana);
        if (UICoinDisplay.Instance.GetCoinCount() >= recoverManaCost)
        {
            UICoinDisplay.Instance.coinCount -= recoverManaCost;
            healthAndMana.healMana(playerMana.currentMana, playerManaRecover);
            Debug.Log("Bought Mana recovery!");
            Debug.Log("currentMANA: " + playerMana.currentMana);
        }
        else
        {
            Debug.Log("Not enough coins!");
        }

    }
}
