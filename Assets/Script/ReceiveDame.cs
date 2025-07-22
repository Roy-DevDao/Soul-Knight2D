using System.Collections;
using UnityEngine;

public class ReceiveDame : MonoBehaviour
{
    public Color flashColor = Color.red;
    public float flashDuration = 0.1f;

    private SpriteRenderer sprite;
    private Color originalColor;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        originalColor = sprite.color;
    }

    public void FlashOnDamage()
    {
        StopAllCoroutines();
        StartCoroutine(FlashEffect());
    }

    private System.Collections.IEnumerator FlashEffect()
    {
        sprite.color = flashColor;
        yield return new WaitForSeconds(flashDuration);
        sprite.color = originalColor;
    }


}
