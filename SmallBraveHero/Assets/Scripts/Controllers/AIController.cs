using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : CharacterController
{
    public float TauntRange { get => tauntRange; }
    [SerializeField] float tauntRange;
    public float TauntDuration { get => tauntDuration; }
    [SerializeField] float tauntDuration;

    
}
