using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
     public Button recoverHpButton;
     public TextMeshProUGUI coinText;

     public int recoverHpCost = 5;
     public int playerHPRecover = 30;

     public UICoinDisplay uiCoinDisplay;
     public HealthAndMana healthAndMana;
     public PlayerHealth playerHealth;


    void Start()
     {

         if (recoverHpButton != null)
             recoverHpButton.onClick.AddListener(BuyHealth);
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
}
