using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallState : BaseState
{
    public FallState(CharacterController controller, StateMachine stateMachine) : base(controller, stateMachine)
    {
    }

    public override void Enter()
    {
        movementVector = Vector3.zero;
        controller.CharacterAnimator.Play(controller.CharacterAnimPrefix + EStateType.Fall);
        
    }

    public override void Exit()
    {
        
    }

    public override void UpdateInput()
    {
        movementVector.x = controller.Direction * controller.MoveSpeed;
        movementVector.y -= controller.Gravity * Time.deltaTime;       
    }

    public override void UpdateLogic()
    {
        controller.FlipSprite();

        if (controller.IsTouchingLeftWall && controller.Direction < 0)
        {
            movementVector.x = 0;
        }

        if (controller.IsTouchingRightWall && controller.Direction > 0)
        {
            movementVector.x = 0;
        }

        if (controller.IsGrounded)
        {
            controller.FixCharacterGroundPosition();

            if (controller.Direction != 0)
            {
                stateMachine.ChangeState(EStateType.Run);
            }

            stateMachine.ChangeState(EStateType.Idle);
        }       

        controller.transform.position += movementVector * Time.deltaTime;
    }

    public override void UpdatePhysics()
    {
        
    }
}
