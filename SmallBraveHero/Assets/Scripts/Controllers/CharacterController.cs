using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterController : MonoBehaviour
{
    public Vector2 MovementVector { get => movementVector; }
    [SerializeField] protected Vector2 movementVector;

    public float MoveSpeed { get => moveSpeed; }
    [SerializeField] protected float moveSpeed;

    public float JumpHeight { get => jumpHeight; }
    [SerializeField] protected float jumpHeight;  
}
