using UnityEngine;
using System.Collections;
using TMPro;

public class UIController : MonoBehaviour
{
    private static UIController _instance;
    public static UIController Instance
    {
        get { return _instance; }
    }

    public TextMeshProUGUI weaponOnHoverInfo;
    public TextMeshProUGUI weaponOnHoverDamage;

    public TextMeshProUGUI chestInstructionText;
    public TextMeshProUGUI chestRewardText;
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        } 
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void updateWeaponOnHover(string name, float damage, float damageDiff)
    {
        string prefix = damageDiff >= 0 ? "+" : "-";
        weaponOnHoverInfo.text = $"{name} (Q)";
        weaponOnHoverDamage.text = $"{damage} DMG ({prefix}{damageDiff})";
        showWeaponOnHover();
    }

    public void showWeaponOnHover(bool isShow = true)
    {
        if (weaponOnHoverInfo != null && weaponOnHoverInfo.gameObject != null)
        {
            weaponOnHoverInfo.gameObject.SetActive(isShow);
        }
        else
        {
            Debug.LogWarning("weaponOnHoverInfo đã bị huỷ hoặc null.");
        }

        if (weaponOnHoverDamage != null && weaponOnHoverDamage.gameObject != null)
        {
            weaponOnHoverDamage.gameObject.SetActive(isShow);
        }
        else
        {
            Debug.LogWarning("weaponOnHoverDamage đã bị huỷ hoặc null.");
        }
    }


    public void ShowChestInstruction(bool isShow = true)
    {
        if (chestInstructionText != null)
            chestInstructionText.gameObject.SetActive(isShow);
        Debug.Log("GUILDDDDDDDDDDDDDDDDDDDDDD");
    }

    public void ShowChestReward(string message)
    {
        if (chestRewardText != null)
        {
            chestRewardText.text = message;
            chestRewardText.gameObject.SetActive(true);
            StartCoroutine(HideChestRewardAfterDelay());
        }
    }

    private IEnumerator HideChestRewardAfterDelay()
    {
        yield return new WaitForSeconds(2f);
        if (chestRewardText != null)
        {
            chestRewardText.gameObject.SetActive(false);
        }
    }


    private void OnDestroy()
    {
        if (_instance == this)
        {
            _instance = null;
        }
    }
}
