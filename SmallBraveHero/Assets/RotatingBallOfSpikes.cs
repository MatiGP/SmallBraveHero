using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingBallOfSpikes : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 4f;
    [SerializeField] Transform chainRoot;
  
    // Update is called once per frame
    void Update()
    {
        chainRoot.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
