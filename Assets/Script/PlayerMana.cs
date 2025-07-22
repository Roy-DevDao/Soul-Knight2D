using UnityEngine;
using UnityEngine.Events;

public class PlayerMana : MonoBehaviour
{
    int maxMana = 50;
    public int currentMana;
    public UnityEvent onDeath;
    public HealthAndMana healthAndMana;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentMana = 20;
    }

    private void OnEnable()
    {
        onDeath.AddListener(Death);
    }
    public void OnDisable()
    {
        onDeath.RemoveListener(Death);
    }
    
    public void Death()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
