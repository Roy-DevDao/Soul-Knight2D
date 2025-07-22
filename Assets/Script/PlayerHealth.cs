//using UnityEngine;
//using UnityEngine.Events;

//public class PlayerHealth : MonoBehaviour
//{
//    int maxHealth = 100;
//    public int currentHealth;
//    public UnityEvent onDeath;

//    // Start is called once before the first execution of Update after the MonoBehaviour is created
//    void Start()
//    {
//        currentHealth = maxHealth;
//    }

//    private void OnEnable()
//    {
//        onDeath.AddListener(Death);
//    }
//    public void OnDisable()
//    {
//        onDeath.RemoveListener(Death);
//    }
//    public void TakeDamage(int damage)
//    {
//        currentHealth -= damage;
//        if (currentHealth < 0)
//        {
//            currentHealth = 0;
//            onDeath.Invoke();
//        }            
//        healthAndMana.UpdateHealthBar(currentHealth, maxHealth);
//    }
//    public void Death()
//    {
//        Destroy(gameObject);
//    }

//    // Update is called once per frame
//    void Update()
//    {
        
//    }
//}
