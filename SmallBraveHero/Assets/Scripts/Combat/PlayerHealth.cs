using Code.Combat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Health
{
    [SerializeField] private Stat[] playerStats;

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
}
