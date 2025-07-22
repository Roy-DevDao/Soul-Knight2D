using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameManager : MonoBehaviour
{
    public Button creditButton;
    private void Start()
    {
        creditButton.onClick.AddListener(ToCredit);
    }
    public void ToCredit()
    {
        SceneManager.LoadScene("EndCreditScence");
    }
}
