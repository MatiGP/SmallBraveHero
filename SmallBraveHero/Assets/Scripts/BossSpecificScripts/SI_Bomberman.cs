using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SI_Bomberman : MonoBehaviour
{
    [SerializeField] private Transform[] teleportationPoints;

    public void TeleportToRandomPoint()
    {
        int newTpLocationIndex = Random.Range(0, teleportationPoints.Length);

        transform.position = teleportationPoints[newTpLocationIndex].position;
    }
}
