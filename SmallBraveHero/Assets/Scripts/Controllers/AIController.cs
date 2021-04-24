using Code.StateMachine.AI.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Code.StateMachine.AI
{
    public class AIController : CharacterController
    {
        [Header("Enemy Settings")]
        [SerializeField] float tauntRange;
        public float TauntRange { get => tauntRange; }      
        public float TauntDuration { get => tauntDuration; }
        [SerializeField] float tauntDuration;
        public float PatrolMoveSpeed { get => patrolMoveSpeed; }
        [SerializeField] float patrolMoveSpeed;
        public float AttackRange { get => attackRange; }
        [SerializeField] float attackRange;

        public PlayerController Target { get; private set; }

        [SerializeField] AttackManager attackManager;
        public AttackManager AttackManager { get => attackManager; }

        [Header("States")]
        [SerializeField] AIState currentState;
        [SerializeField] AIState remainState;

        protected override void Awake()
        {
            base.Awake();
            characterAnimPrefix = "Enemy_";
            direction = 1;
        }

        private void Update()
        {
            currentState.UpdateState(this);
        }

        private void Start()
        {
            CalculateGravity();
        }
       
        private void FixedUpdate()
        {
            CheckForCollisions();
        }

        public void SetTarget(PlayerController target)
        {
            Target = target;
        }

        public void TransitionToState(AIState nextState)
        {
            if(nextState != remainState)
            {
                currentState = nextState;
            }
        }        
    }
}
