using Code.StateMachine.AI.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Code.StateMachine.AI
{
    public class AIController : CharacterController
    {
        public float TauntRange { get => tauntRange; }
        [SerializeField] float tauntRange;
        public float TauntDuration { get => tauntDuration; }
        [SerializeField] float tauntDuration;
        public float PatrolMoveSpeed { get => patrolMoveSpeed; }
        [SerializeField] float patrolMoveSpeed;

        public PlayerController Target { get; private set; }

        [SerializeField] AIState currentState;
        [SerializeField] AIState remainState;

        private void Awake()
        {

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
