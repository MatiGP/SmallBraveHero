using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FistController : MonoBehaviour
{
    [SerializeField] private GameObject leftFist = null;
    public GameObject LeftFist { get => leftFist; }

    [SerializeField] private GameObject rightFist = null;
    public GameObject RightFist { get => rightFist; }

    public void Smash()
    {

    }

    public bool IsUnderLeftFist()
    {
        return Physics2D.Raycast(leftFist.transform.position, leftFist.transform.position + Vector3.down, 15f, LayerMask.NameToLayer("Player"));
    }
}
