using Code.StateMachine.AI.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Code.StateMachine.AI
{
    public class AIController : CharacterController
    {
        [SerializeField] private SpriteRenderer spriteRenderer = null;

        [Header("Enemy Settings")]
        [SerializeField] private float tauntRange = 1;
        public float TauntRange { get => tauntRange; }      
        public float TauntDuration { get => tauntDuration; }
        [SerializeField] private float tauntDuration = 1;
        public float PatrolMoveSpeed { get => patrolMoveSpeed; }
        [SerializeField] private float patrolMoveSpeed = 2;
        public float AttackRange { get => attackRange; }
        [SerializeField] private float attackRange = 0.5f;
        [SerializeField] private Vector3 platformCheckOffset = new Vector3();

        public Animator CharacterAnimator { get => characterAnimator; }
        [SerializeField] Animator characterAnimator = null;

        [SerializeField] private PlayerController target = null;
        public PlayerController Target { get => target; }

        [SerializeField] private AttackManager attackManager = null;
        public AttackManager AttackManager { get => attackManager; }

        [Header("States")]
        [SerializeField] private AIState currentState = null;
        [SerializeField] private AIState remainState = null;
        public AIState RemainInState { get => remainState; }

        private bool reachedEndOfPlatform = false;
        public bool ReachedEndOfPlatform { get => reachedEndOfPlatform; }

        public bool IsCharacterPerformingAction { get => isCharacterPerformingAction; }
        protected bool isCharacterPerformingAction = false;

        private Vector3 checkPosition = new Vector3();

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

            Collider2D groundCollider = null;

            checkPosition = transform.position;
            checkPosition.x += platformCheckOffset.x * direction;
            checkPosition.y += platformCheckOffset.y;

            groundCollider = Physics2D.OverlapCircle(checkPosition, 0.2f, groundLayer);

            reachedEndOfPlatform = groundCollider == null;


        }

        public void SetTarget(PlayerController target)
        {
            this.target = target;
        }

        public void TransitionToState(AIState nextState)
        {
            if(nextState != remainState)
            {
                currentState = nextState;
            }
        }
        
        public void SetDirection(float value)
        {
            direction = value;
        }

        public void LockCharacter()
        {
            isCharacterPerformingAction = true;
            Debug.Log("Locking Character");
        }

        public void UnLockCharacter()
        {
            isCharacterPerformingAction = false;
            Debug.Log("Unlocking Character");
        }

        public override void FlipSprite()
        {
            if(direction == 1)
            {
                spriteRenderer.flipX = false;
            }
            else if(direction == -1)
            {
                spriteRenderer.flipX = true;
            }
        }

        protected override void OnDrawGizmos()
        {
            base.OnDrawGizmos();

            Gizmos.color = Color.magenta;
            Gizmos.DrawLine(transform.position, transform.position + Vector3.right * tauntRange);
            Gizmos.color = Color.white;
            Gizmos.DrawWireSphere(platformCheckOffset, 0.2f);
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(transform.position + Vector3.down * 0.4f, transform.position + Vector3.down * 0.4f + Vector3.right * attackRange);
        }
    }
}
