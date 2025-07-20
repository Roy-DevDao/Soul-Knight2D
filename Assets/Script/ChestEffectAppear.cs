using System.Collections;
using UnityEngine;

public class ChestEffectAppear : MonoBehaviour
{
    public float appearDuration = 0.5f;

    public void PlayAppearEffect()
    {
        StopAllCoroutines(); 
        StartCoroutine(ScaleUp());
    }

    IEnumerator ScaleUp()
    {
        transform.localScale = Vector3.zero;
        Vector3 targetScale = Vector3.one;
        float timer = 0f;

        while (timer < appearDuration)
        {
            transform.localScale = Vector3.Lerp(Vector3.zero, targetScale, timer / appearDuration);
            timer += Time.deltaTime;
            yield return null;
        }

        transform.localScale = targetScale;
    }
}
