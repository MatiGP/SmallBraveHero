using Code.Combat;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Health
{
    public static event Action<PlayerHealth> OnPlayerDamageTaken;

    [SerializeField] private Stat[] playerStats;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        OnPlayerDamageTaken.Invoke(this);
    }

    public void IncreaseStat(EAttribute attribute, int value)
    {
        playerStats[(int)attribute].Increase(value);
    }

    public void DecreaseStat(EAttribute attribute, int value)
    {
        playerStats[(int)attribute].Decrease(value);
    }

    public int GetStat(EAttribute attribute)
    {
        return playerStats[(int)attribute].Value;
    }

    public override void TakeDamage(int damageAmount)
    {
        base.TakeDamage(damageAmount);
        OnPlayerDamageTaken.Invoke(this);
    }


}
