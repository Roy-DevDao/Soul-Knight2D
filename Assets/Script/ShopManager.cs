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


    void Start()
     {

        if (recoverHpButton != null)
        {
            recoverHpButton.onClick.AddListener(BuyHealth);
        }
    }
        //if (recoverManaButton != null)
        //    recoverManaButton.onClick.AddListener(BuyMana);
    

     void Update()
     {
         if (coinText != null)
         {
             coinText.text = "x " + UICoinDisplay.Instance.GetCoinCount();
         }
     }

    public void BuyHealth()
    {
        Debug.Log("BAT DAU");
        if (UICoinDisplay.Instance.GetCoinCount() >= recoverHpCost)
        {
            Debug.Log("BAT DAU TINH TIEN");
            UICoinDisplay.Instance.coinCount -= recoverHpCost;

            ParametersScript.healValue += playerHPRecover;
            if (ParametersScript.healValue > 1000)
                ParametersScript.healValue = 1000;

            Debug.Log("Bought HP recovery! Current Heal: " + ParametersScript.healValue);
        }
        else
        {
            Debug.Log("Not enough coins!");
        }
    }

    //public void BuyMana()
    //{
    //    if (UICoinDisplay.Instance.GetCoinCount() >= recoverManaCost)
    //    {
    //        UICoinDisplay.Instance.coinCount -= recoverManaCost;
    //        healthAndMana.healMana(playerMana.currentMana, playerManaRecover);
    //        Debug.Log("Bought Mana recovery!");
    //        Debug.Log("currentMANA: " + playerMana.currentMana);
    //    }
    //    else
    //    {
    //        Debug.Log("Not enough coins!");
    //    }

    //}
}
