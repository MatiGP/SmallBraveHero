using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : BaseState
{
    public JumpState(CharacterController controller, StateMachine stateMachine) : base(controller, stateMachine)
    {
    }

    public override void Enter()
    {
        movementVector.y = controller.JumpHeight;
        movementVector.x = 0;
        controller.CharacterAnimator.Play(controller.CharacterAnimPrefix + EStateType.Jump);
    }

    public override void Exit()
    {
        movementVector = Vector2.zero;
    }

    public override void UpdateInput()
    {
        movementVector.x = controller.Direction * controller.MoveSpeed;
        movementVector.y -= controller.Gravity * Time.deltaTime;

        

    }

    public override void UpdateLogic()
    {
        controller.FlipSprite();

        if (movementVector.y < 0)
        {
            stateMachine.ChangeState(EStateType.Fall);
        }

        if (controller.IsTouchingLeftWall && controller.Direction < 0)
        {
            movementVector.x = 0;
        }

        if (controller.IsTouchingRightWall && controller.Direction > 0)
        {
            movementVector.x = 0;
        }

        controller.transform.position += movementVector * Time.deltaTime;
    }

    public override void UpdatePhysics()
    {
        
    }
}
