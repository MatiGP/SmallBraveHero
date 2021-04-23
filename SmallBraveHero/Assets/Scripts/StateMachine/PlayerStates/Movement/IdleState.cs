using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{
    public IdleState(PlayerController controller, StateMachine stateMachine) : base(controller, stateMachine)
    {
    }

    public override void Enter()
    {
        movementVector = Vector2.zero;
        controller.CharacterAnimator.Play(controller.CharacterAnimPrefix + EStateType.Idle);
    }

    public override void Exit()
    {
        movementVector = Vector2.zero;
    }

    public override void UpdateInput()
    {
        
    }

    public override void UpdateLogic()
    {
        if(controller.Direction != 0)
        {
            stateMachine.ChangeState(EStateType.Run);
        }

        if (controller.IsJumping)
        {
            stateMachine.ChangeState(EStateType.Jump);
        }

        if (!controller.IsGrounded)
        {
            stateMachine.ChangeState(EStateType.Fall);
        }

        if (controller.IsDodging)
        {
            stateMachine.ChangeState(EStateType.ActiveDodge);
        }
    }

    public override void UpdatePhysics()
    {
        
    }
}
