using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterController : MonoBehaviour
{
    [Header("Layers")]
    [SerializeField] LayerMask groundLayer;
    [SerializeField] LayerMask wallLayer;
    public bool Gizmo;

    [Header("General References")]
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] BoxCollider2D characterCollider;
    [SerializeField] Health characterHealth;
    public Health CharacterHealth { get => characterHealth; }
    
    public Animator CharacterAnimator { get => characterAnimator; }
    [SerializeField] Animator characterAnimator;

    public float MoveSpeed { get => moveSpeed; }
    [Header("Movement Settings")]
    [SerializeField] protected float moveSpeed;

    public float JumpHeight { get => jumpHeight; }
    [SerializeField] protected float jumpHeight;

    public float JumpDuration { get => jumpDuration; }
    [SerializeField] protected float jumpDuration;

    [SerializeField] protected float wallPosOffset = 0.2f;

    public float Gravity { get => gravity; }
    protected float gravity;

    public float Direction { get => direction; }
    protected float direction;

    public bool IsJumping { get => isJumping; }
    protected bool isJumping;

    public bool IsTouchingCeiling { get => isTouchingCeiling; }
    protected bool isTouchingCeiling;

    public bool IsGrounded { get => isGrounded; }
    protected bool isGrounded;

    public bool IsTouchingLeftWall { get => isTouchingLeftWall; }
    protected bool isTouchingLeftWall;

    public bool IsTouchingRightWall { get => isTouchingRightWall; }
    protected bool isTouchingRightWall;

    public string CharacterAnimPrefix { get => characterAnimPrefix; }
    protected string characterAnimPrefix;

    [Header("Detectors")]
    [SerializeField] Transform groundDetector;
    [SerializeField] Vector2 groundDetectorSize;
    [SerializeField] Transform ceilingDetector;
    [SerializeField] Vector2 ceilingDetectorSize;
    [SerializeField] Transform wallDetectorRight;
    [SerializeField] Transform wallDetectorLeft;
    [SerializeField] Vector2 wallDetectorSize;

    protected void Awake()
    {
        characterHealth = GetComponent<Health>();
    }

    protected void CheckForCollisions()
    {
        isGrounded = Physics2D.OverlapBox(groundDetector.position, groundDetectorSize, 0f, groundLayer);
        isTouchingCeiling = Physics2D.OverlapBox(ceilingDetector.position, ceilingDetectorSize, 0f, groundLayer);
        isTouchingLeftWall = Physics2D.OverlapBox(wallDetectorLeft.position, wallDetectorSize, 0f, wallLayer);
        isTouchingRightWall = Physics2D.OverlapBox(wallDetectorRight.position, wallDetectorSize, 0f, wallLayer);
    }

    public void FixCharacterGroundPosition()
    {
        float floorPos = Physics2D.Raycast(transform.position, transform.position + Vector3.down, 5f, groundLayer).point.y;
        transform.position = new Vector3(transform.position.x, floorPos + (characterCollider.size.y / 2));
    }

    public void FixCharacterWallPosition()
    {
        float wallPos;

        if (IsTouchingLeftWall)
        {
            wallPos = Physics2D.OverlapBox(wallDetectorLeft.position, wallDetectorSize, 0f, wallLayer).ClosestPoint(transform.position).x + wallPosOffset;
            
        }
        else
        {
            wallPos = Physics2D.OverlapBox(wallDetectorRight.position, wallDetectorSize, 0f, wallLayer).ClosestPoint(transform.position).x - wallPosOffset;
        }

        wallPos += characterCollider.size.x / 2;

        transform.position = new Vector3(wallPos, transform.position.y);
    }

    protected void CalculateGravity()
    {
        gravity = (2 * jumpHeight) / (jumpDuration * jumpDuration);
    }

    public void ChangeDirection()
    {
        direction *= -1;      
    }

    public void FlipSprite()
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

    protected void OnDrawGizmos()
    {
        if (!Gizmo) return;

        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(groundDetector.position, groundDetectorSize);
        Gizmos.color = Color.red;
        Gizmos.DrawCube(ceilingDetector.position, ceilingDetectorSize);
        Gizmos.color = Color.green;
        Gizmos.DrawCube(wallDetectorRight.position, wallDetectorSize);
        Gizmos.DrawCube(wallDetectorLeft.position, wallDetectorSize);

        
    }

    

}
