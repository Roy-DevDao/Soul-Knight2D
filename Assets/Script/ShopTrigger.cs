using UnityEngine;
using TMPro;

public class ShopTrigger : MonoBehaviour
{
    public GameObject shopUI; // Assign your shop panel UI here
    public TextMeshProUGUI promptText; // Assign the TMP text (e.g., "Press E to open shop")
    private bool playerInRange = false;

    void Start()
    {
        if (promptText != null)
        {
            promptText.gameObject.SetActive(false); // Hide prompt at start
        }

        if (shopUI != null)
        {
            shopUI.SetActive(false); // Hide shop UI at start
        }
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (shopUI != null)
            {
                shopUI.SetActive(true); // Show shop UI
            }
            


            if (promptText != null)
            {
                promptText.gameObject.SetActive(false); // Hide prompt when shop opens
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;

            if (promptText != null)
            {
                promptText.gameObject.SetActive(true); // Show "Press E" prompt
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;

            if (promptText != null)
            {
                promptText.gameObject.SetActive(false); // Hide prompt
            }

            if (shopUI != null)
            {
                shopUI.SetActive(false); // Optionally hide shop UI when player leaves
            }
        }
    }
}
