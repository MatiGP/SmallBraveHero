using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public static event Action<int, Vector3> OnDamageTaken;
    public static event Action<int, Vector3> OnHealUp;

    [SerializeField] private Transform popUpOffsetPos;

    [SerializeField] int maxHealth;
    public int MaxHealth { get { return maxHealth; } }

    int currentHealth;
    public int CurrentHealth { get { return currentHealth; } }

    [SerializeField] int defence;
    public int Defence { get { return defence; } }

    [SerializeField] private float damageInvulnerabilityDuration = 0.3f;
    private float currentDamageInvulnerabilityDuration;

    public string PreviousDamageTaken { get; private set; }

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

    public virtual void TakeDamage(int damageAmount)
    {
        if(currentDamageInvulnerabilityDuration > 0)
        {
            return;
        }

        Debug.Log($"Taking damage: -{damageAmount}");

        int damageToTake = Mathf.Clamp(damageAmount - defence, 0, int.MaxValue);

        PreviousDamageTaken = "-" + damageToTake;

        currentHealth -= damageToTake;
        currentDamageInvulnerabilityDuration = damageInvulnerabilityDuration;

        OnDamageTaken.Invoke(damageToTake, Camera.main.WorldToScreenPoint(popUpOffsetPos.position));

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void Heal(int healAmount)
    {
        Debug.Log($"Healing damage: +{healAmount}");

        PreviousDamageTaken = "+" + healAmount;

        currentHealth = Mathf.Clamp(currentHealth + healAmount, 1, maxHealth);

        OnHealUp.Invoke(healAmount, Camera.main.WorldToScreenPoint(popUpOffsetPos.position));
    }

    
}
