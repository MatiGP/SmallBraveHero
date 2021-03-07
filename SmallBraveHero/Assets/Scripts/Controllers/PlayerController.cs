using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterController
{   
    public float WallJumpHeight { get => wallJumpHeight; }
    [Header("WallJumps")]
    [SerializeField] float wallJumpHeight;

    public float WallSlideSpeed { get => wallSlideSpeed; }
    [Header("WallSlides")]
    [SerializeField] float wallSlideSpeed;

    public StateMachine stateMachine { get; private set; }

    private void Awake()
    {
        stateMachine = new StateMachine();
        characterAnimPrefix = "Player_";
    }

    private void Start()
    {
        stateMachine.Initialize();

        stateMachine.AddState(EStateType.Run, new RunState(this, stateMachine));
        stateMachine.AddState(EStateType.Idle, new IdleState(this, stateMachine));
        stateMachine.AddState(EStateType.Jump, new JumpState(this, stateMachine));
        stateMachine.AddState(EStateType.Fall, new FallState(this, stateMachine));

        stateMachine.Start();

        CalculateGravity();
    }

    private void Update()
    {
        direction = Input.GetAxisRaw("Horizontal");
        isJumping = Input.GetAxis("Jump") > 0;

        stateMachine.CurrentState.UpdateLogic();
    }

    private void LateUpdate()
    {
        stateMachine.CurrentState.UpdateInput();
    }

    private void FixedUpdate()
    {
        CheckForCollisions();

        stateMachine.CurrentState.UpdatePhysics();
    }



}
