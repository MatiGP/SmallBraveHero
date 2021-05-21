using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : CharacterController
{
    [SerializeField] private PlayerModelController modelController;
    public PlayerModelController PlayerModel { get => modelController; }

    public float WallJumpHeight { get => wallJumpHeight; }
    [Header("WallJumps")]
    [SerializeField] float wallJumpHeight;

    public float WallSlideSpeed { get => wallSlideSpeed; }
    [Header("WallSlides")]
    [SerializeField] float wallSlideSpeed;

    public float ActiveDodgeSpeed { get => dodgeSpeed; }
    [Header("Dodges")]
    [SerializeField] float dodgeSpeed;
    public float ActiveDodgeDuration { get => dodgeDuration; }
    [SerializeField] float dodgeDuration;
    public bool IsDodging { get; private set; }

    public StateMachine stateMachine { get; private set; }

    private PlayerControls controls;
    public PlayerControls PlayerControls { get => controls; }

    public override bool IsFacingRight { get => PlayerModel.Direction == 1; }

    private void OnDisable()
    {
        UnBindControls();
    }

    protected override void Awake()
    {
        base.Awake();
        stateMachine = new StateMachine();
        characterAnimPrefix = "Player_";
        controls = new PlayerControls();
        BindControls();
    }

    private void Start()
    {
        InitializePlayerStateMachine();
        CalculateGravity();
    }

    void BindControls()
    {
        controls.Gameplay.MoveLeftRight.performed += MoveLeftRight_performed;
        controls.Gameplay.MoveLeftRight.canceled += MoveLeftRight_canceled;
        controls.Gameplay.MoveLeftRight.Enable();

        controls.Gameplay.Jump.performed += Jump_performed;
        controls.Gameplay.Jump.canceled += Jump_canceled;
        controls.Gameplay.Jump.Enable();

        controls.Gameplay.ActiveDodge.performed += ActiveDodge_performed;
        controls.Gameplay.ActiveDodge.canceled += ActiveDodge_canceled;
        controls.Gameplay.ActiveDodge.Enable();

        
    }
    
    void UnBindControls()
    {
        controls.Gameplay.MoveLeftRight.performed -= MoveLeftRight_performed;
        controls.Gameplay.MoveLeftRight.canceled -= MoveLeftRight_canceled;
        controls.Gameplay.MoveLeftRight.Disable();

        controls.Gameplay.Jump.performed -= Jump_performed;
        controls.Gameplay.Jump.canceled -= Jump_canceled;
        controls.Gameplay.Jump.Enable();

        controls.Gameplay.ActiveDodge.performed -= ActiveDodge_performed;
        controls.Gameplay.ActiveDodge.canceled -= ActiveDodge_canceled;
        controls.Gameplay.ActiveDodge.Enable();
    }

    private void Jump_performed(InputAction.CallbackContext context)
    {
        isJumping = context.ReadValue<float>() > 0.9f;
    }

    private void MoveLeftRight_performed(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<float>();
    }

    private void MoveLeftRight_canceled(InputAction.CallbackContext obj)
    {
        direction = 0f;
    }

    private void ActiveDodge_canceled(InputAction.CallbackContext obj)
    {
        IsDodging = false;
    }

    private void Jump_canceled(InputAction.CallbackContext obj)
    {
        isJumping = false;
    }

    private void ActiveDodge_performed(InputAction.CallbackContext context)
    {
        IsDodging = context.ReadValue<float>() > 0.9f;
    }

    private void InitializePlayerStateMachine()
    {
        stateMachine.Initialize();

        stateMachine.AddState(EStateType.Run, new RunState(this, stateMachine));
        stateMachine.AddState(EStateType.Idle, new IdleState(this, stateMachine));
        stateMachine.AddState(EStateType.Jump, new JumpState(this, stateMachine));
        stateMachine.AddState(EStateType.Fall, new FallState(this, stateMachine));
        stateMachine.AddState(EStateType.ActiveDodge, new ActiveDodge(this, stateMachine));

        stateMachine.Start();
    }

    private void Update()
    {
        stateMachine.CurrentState.UpdateInput();
        stateMachine.CurrentState.UpdateLogic();
    }

  
    public override void FlipSprite()
    {
        modelController.FlipBodyRenderer(direction);       
    }

    private void FixedUpdate()
    {
        CheckForCollisions();

        stateMachine.CurrentState.UpdatePhysics();
    }   
}
