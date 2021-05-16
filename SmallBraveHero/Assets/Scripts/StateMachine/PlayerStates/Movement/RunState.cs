using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : BaseState
{
    public RunState(PlayerController controller, StateMachine stateMachine) : base(controller, stateMachine)
    {
    }

    public override void Enter()
    {
        movementVector = Vector3.zero;
        controller.PlayerModel.PlayAnimation(controller.CharacterAnimPrefix + EStateType.Run);
        controller.PlayerModel.PlayArmsAnimation(controller.CharacterAnimPrefix + EStateType.Run);
    }

    public override void Exit()
    {
        movementVector = Vector3.zero;
    }

    public override void UpdateInput()
    {
        movementVector.x = controller.Direction * controller.MoveSpeed;      
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

        if (controller.IsDodging)
        {
            stateMachine.ChangeState(EStateType.ActiveDodge);
        }

        controller.transform.position += movementVector * Time.deltaTime;
    }

    public override void UpdatePhysics()
    {
        
    }
}
