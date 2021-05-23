using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterController : MonoBehaviour
{
    [Header("Layers")]
    [SerializeField] protected LayerMask groundLayer;
    [SerializeField] protected LayerMask wallLayer;
    public bool Gizmo;
 
    public virtual bool IsFacingRight { get; }

    [Header("General References")]
    [SerializeField] private BoxCollider2D characterCollider = null;
    [SerializeField] private Health characterHealth = null;
    public Health CharacterHealth { get => characterHealth; }

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

    public float GroundOffset { get => groundOffset; }
    [SerializeField] protected float groundOffset = 0.1f;

    [Header("Detectors")]
    [SerializeField] Transform groundDetector;
    [SerializeField] Vector2 groundDetectorSize;
    [SerializeField] Transform ceilingDetector;
    [SerializeField] Vector2 ceilingDetectorSize;
    [SerializeField] Transform wallDetectorRight;
    [SerializeField] Transform wallDetectorLeft;
    [SerializeField] Vector2 wallDetectorSize;

    protected virtual void Awake()
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
        float floorPos = Physics2D.OverlapBox(groundDetector.position, groundDetectorSize, 0f, groundLayer).ClosestPoint(transform.position).y;
        transform.position = new Vector3(transform.position.x, floorPos + (characterCollider.size.y / 2) + groundOffset);
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

    public abstract void FlipSprite();

    protected virtual void OnDrawGizmos()
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
