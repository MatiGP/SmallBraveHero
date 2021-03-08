using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : BaseState
{
    public RunState(CharacterController controller, StateMachine stateMachine) : base(controller, stateMachine)
    {
    }

    public override void Enter()
    {
        movementVector = Vector3.zero;
        controller.CharacterAnimator.Play(controller.CharacterAnimPrefix + EStateType.Run);
    }

    public override void Exit()
    {
        movementVector = Vector3.zero;
    }

    public override void UpdateInput()
    {
        movementVector.x = controller.Direction * controller.MoveSpeed;

        controller.transform.position += movementVector * Time.deltaTime;

    }

    public override void UpdateLogic()
    {
        controller.FlipSprite();

        if(controller.IsTouchingLeftWall || controller.IsTouchingRightWall)
        {
            movementVector.x = 0;            
        }

        if (controller.IsJumping)
        {
            stateMachine.ChangeState(EStateType.Jump);
        }

        if (!controller.IsGrounded)
        {
            stateMachine.ChangeState(EStateType.Fall);
        }

        if(controller.Direction == 0)
        {
            stateMachine.ChangeState(EStateType.Idle);
        }

        
    }

    public override void UpdatePhysics()
    {
        
    }
}
