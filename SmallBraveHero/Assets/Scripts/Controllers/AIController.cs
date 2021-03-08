using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : CharacterController
{
    public float TauntRange { get => tauntRange; }
    [SerializeField] float tauntRange;
    public float TauntDuration { get => tauntDuration; }
    [SerializeField] float tauntDuration;

    public StateMachine stateMachine { get; private set; }

    private void Awake()
    {
        stateMachine = new StateMachine();
        characterAnimPrefix = "Enemy_";
        direction = 1;
    }

    private void Start()
    {
        stateMachine.Initialize();

        stateMachine.AddState(EStateType.Patrol, new PatrolState(this, stateMachine));
        //stateMachine.AddState(EStateType.Fall, new FallState(this, stateMachine)); Refactor
        
        stateMachine.Start();

        CalculateGravity();
    }

    private void Update()
    {
        
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
