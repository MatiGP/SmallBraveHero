using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SI_Healer : MonoBehaviour
{
    [Header("Healer stuff")]

    [SerializeField] private Health[] otherBossesHealth;
    [SerializeField] private int healValue = 5;

    [Header("Teleport Points")]
    [SerializeField] private Transform[] teleportPoints;
    private int currentIndex = 0;
   
    public void HealRandomBoss()
    {
        if(otherBossesHealth == null)
        {
            return;
        }

        otherBossesHealth[Random.Range(0, 2)].Heal(healValue);
    }

    public void TeleportAway()
    {
        currentIndex++;

        transform.position = teleportPoints[currentIndex % 2].position;
    }
}
