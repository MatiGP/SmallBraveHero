using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterController
{
    public float WallJumpHeight { get => wallJumpHeight; }
    [SerializeField] float wallJumpHeight;

    public float WallSlideSpeed { get => wallSlideSpeed; }
    [SerializeField] float wallSlideSpeed;

    [SerializeField] float jumpDuration;
    
}
