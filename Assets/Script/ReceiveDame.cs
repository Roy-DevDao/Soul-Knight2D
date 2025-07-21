using System.Collections;
using UnityEngine;

public class ReceiveDame : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public float flashDuration = 0.2f;
    private Color originalColor;

    void Start()
    {
        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();

        originalColor = spriteRenderer.color;
    }

    public void FlashRed()
    {
        StartCoroutine(FlashCoroutine());
    }

    private IEnumerator FlashCoroutine()
    {
        spriteRenderer.color = Color.red; 
        yield return new WaitForSeconds(flashDuration);
        spriteRenderer.color = originalColor; 
    }

}
