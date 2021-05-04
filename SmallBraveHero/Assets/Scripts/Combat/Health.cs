using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int maxHealth;
    public int MaxHealth { get { return maxHealth; } }

    int currentHealth;
    public int CurrentHealth { get { return currentHealth; } }

    [SerializeField] int defence;
    public int Defence { get { return defence; } }

    [SerializeField] private float damageInvulnerabilityDuration = 0.3f;
    private float currentDamageInvulnerabilityDuration;

    protected virtual void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if(currentDamageInvulnerabilityDuration > 0)
        {
            currentDamageInvulnerabilityDuration -= Time.deltaTime;
        }
    }

    public void TakeDamage(int damageAmount)
    {
        if(currentDamageInvulnerabilityDuration > 0)
        {
            return;
        }

        Debug.Log($"Taking damage: -{damageAmount}");
        currentHealth -= Mathf.Clamp(damageAmount - defence, 0, int.MaxValue);
        currentDamageInvulnerabilityDuration = damageInvulnerabilityDuration;

        if(currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void Heal(int healAmount)
    {
        Debug.Log($"Healing damage: +{healAmount}");
        currentHealth = Mathf.Clamp(currentHealth + healAmount, 1, maxHealth);
    }

    
}
