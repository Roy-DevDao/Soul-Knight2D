using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.Audio;

public class NextLevel : MonoBehaviour
{
    public TextMeshPro text;
    private bool isPlayerOpen = false;

    //Open and close door
    public Sprite doorOpenSprite;
    public Sprite doorCloseSprite;
    private SpriteRenderer spriteRenderer;

    //Sound
    public AudioSource audioSource;
    public AudioClip doorSound;

    // Use this for initialization
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        text.gameObject.SetActive(isPlayerOpen);
        //if (isPlayerOpen && Input.GetKeyDown(KeyCode.Return))
        //{
        //    Debug.Log("Next Level");
        //    LevelController.Instance.gameObject.SetActive(true);
        //    LevelController.Instance.nextLevel();
        //}
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("OnTriggerStay2D with: " + collision.name);

        if (collision.CompareTag(TAG.PLAYER))
        {
            Debug.Log("Player in trigger zone");
            isPlayerOpen = true;
            audioSource.clip = doorSound;
            audioSource.Play();
            spriteRenderer.sprite = doorOpenSprite;
            Debug.Log("Start coroutine");
            StartCoroutine(AutoNextLevel());
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(TAG.PLAYER))
        {
            isPlayerOpen = false;
            spriteRenderer.sprite = doorCloseSprite;
        }
    }

    IEnumerator AutoNextLevel()
    {
        yield return new WaitForSeconds(1f);

        // Ẩn người chơi, sword
        GameObject player = GameObject.FindGameObjectWithTag(TAG.PLAYER);
        GameObject sword = GameObject.FindGameObjectWithTag(TAG.SWORD);
        if (player != null)
        {
            player.SetActive(false); 
            sword.SetActive(false);
        }
        yield return new WaitForSeconds(0.3f);
        // Đóng cửa lại
        Debug.Log("Đóng cửa");
        audioSource.clip = doorSound;
        audioSource.Play();
        spriteRenderer.sprite = doorCloseSprite;
        text.gameObject.SetActive(false);

        // Gọi LevelController 
        yield return new WaitForSeconds(1.5f);
        Debug.Log("Next Level");
        LevelController.Instance.gameObject.SetActive(true);
        LevelController.Instance.nextLevel();
    }

}
