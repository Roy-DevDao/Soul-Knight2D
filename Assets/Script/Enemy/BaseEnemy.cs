using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BaseEnemy : MonoBehaviour
{
    public Player target;
    public GameObject coinPrefab; // Assign this in Inspector

    public int maxHealth = 10;
    protected float _health = 0f;

    public Slider healthbar;
    private  float knockbackDistance = 3f;

    public float health
    {
        get { return _health; }
    }

    // Use this for initialization
    protected void Start()
    {
        _health = maxHealth;
        healthbar.maxValue = maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collider2D collider = collision;
        ReceiveDame receiveDame = collider.GetComponent<ReceiveDame>();
        Debug.Log("Dungeon: collision " + collider);
        if (collider.tag == TAG.SWORD)
        {
            SwordAttack swordAttack = collider.GetComponent<SwordAttack>();
            if (swordAttack.attacking)
            {
                Debug.Log("Attacked" + swordAttack.baseWeapon.damage);
                Vector2 knockDirection = (transform.position - collision.transform.position).normalized;
                transform.position += (Vector3)(knockDirection * knockbackDistance);
                swordAttack.attacking = false;
                this.GotDamage(swordAttack.baseWeapon.damage, collider);
            }
        }
        else if (collider.tag == TAG.BULLET)
        {
            Bullet bullet = collider.GetComponent<Bullet>();
            if (bullet != null)
            {
                Debug.Log("Attacked" + bullet.GetDamage());
                Vector2 knockDirection = (transform.position - collision.transform.position).normalized;
                transform.position += (Vector3)(knockDirection * knockbackDistance);
                this.GotDamage(bullet.GetDamage(), collider);
            }
        }
    }

    protected void GotDamage(float damage, Collider2D collider)
    {
        this.OnAttacked(collider);
        if (_health >= damage)
        {
            _health -= damage;
        } else
        {
            _health = 0;
            this.OnDie();
        }
    }

    protected virtual void OnAttacked(Collider2D collider) {}
    protected virtual void OnDie() {
        ParametersScript.scoreValue += 10;
 if (coinPrefab != null)
        {
            Instantiate(coinPrefab, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }

    // Update is called once per frame
    protected void Update()
    {
        healthbar.value = this.health;
        healthbar.gameObject.SetActive(healthbar.value < maxHealth);
    }
}
