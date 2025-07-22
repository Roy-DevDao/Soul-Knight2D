using UnityEngine;
using System.Collections;

public class Sword : BaseWeapon
{
    public GameObject slashEffectPrefab;       // Gắn Slash prefab từ Inspector
    public float slashEffectDuration = 0.5f;
    public Transform slashPoint;
    public AudioClip slashSound;               // Âm thanh chém
    private AudioSource audioSource;

    // Use this for initialization
    new void Start()
    {
        base.Start();
        audioSource = GetComponent<AudioSource>();
    }

    protected override Vector3 GetPosition()
    {
        return new Vector3(0f, 0.2f, -1);
    }

    protected override Quaternion GetRotation()
    {
        return Quaternion.Euler(0, 0, -90); // up
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
    }
    public void AttackEffect()
    {
        Debug.Log("⚔️ Gọi AttackEffect!");
        if (slashEffectPrefab != null)
        {
            GameObject effect = Instantiate(
            slashEffectPrefab,
            slashPoint.position,
            slashPoint.rotation * GetRotation()
        );
            Destroy(effect, slashEffectDuration);
        }
        if (slashSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(slashSound);
        }
    }
}