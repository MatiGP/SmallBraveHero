using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    [SerializeField] private float attackDelay;

    private float currentTimeToAttack;

    
    public void HitEvent()
    {
        Debug.Log("EnemyAttacked!");
    }
}
