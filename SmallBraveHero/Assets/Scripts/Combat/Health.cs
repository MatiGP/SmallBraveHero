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

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= Mathf.Clamp(damageAmount - defence, 0, int.MaxValue);
    }

    public void Heal(int healAmount)
    {
        currentHealth = Mathf.Clamp(currentHealth + healAmount, 1, maxHealth);
    }
}
