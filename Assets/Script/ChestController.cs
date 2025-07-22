using UnityEngine;

public class ChestController : MonoBehaviour
{
    public GameObject chestClose;
    public GameObject chestOpen;

    public AudioSource chestOpeningSource;
    public AudioSource chestAppearSource;

    private bool isPlayerInRange = false;
    private bool isOpened = false;

    void Start()
    {
        if (chestClose != null) chestClose.SetActive(false);
        if (chestOpen != null) chestOpen.SetActive(false);

        // Phát âm khi rương xuất hiện
        if (chestAppearSource != null)
        {
            chestAppearSource.Play();
        }
    }

    public void ActivateChest()
    {
        if (chestClose != null) chestClose.SetActive(true);

        // Gợi ý: Bạn có thể phát âm thanh xuất hiện ở đây nếu muốn
        // if (chestAppearSource != null) chestAppearSource.Play();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isOpened)
        {
            isPlayerInRange = true;
            UIController.Instance.ShowChestInstruction(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            UIController.Instance.ShowChestInstruction(false);
        }
    }

    void Update()
    {
        if (isPlayerInRange && !isOpened && Input.GetKeyDown(KeyCode.E))
        {
            OpenChest();
        }
    }

    void OpenChest()
    {
        if (isOpened) return;

        isOpened = true;
        UIController.Instance.ShowChestInstruction(false);
        Debug.Log("Phat ammmmmmmmmmmmmmmmmmmmmm");
        
        if (chestOpeningSource != null)
        {
            Debug.Log("Phat am Thanhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh");

            chestOpeningSource.Play();
        }


        if (chestClose != null) chestClose.SetActive(false);
        if (chestOpen != null) chestOpen.SetActive(true);

        // Phần thưởng
        int reward = Random.Range(0, 2);
        string rewardText = reward == 0
            ? "🎁 +500 máu!"
            : "🎁 +500 điểm!";

        if (reward == 0)
            ParametersScript.healValue += 500;
        else
            ParametersScript.scoreValue += 500;

        Debug.Log(rewardText);
        UIController.Instance.ShowChestReward(rewardText);
    }
}
