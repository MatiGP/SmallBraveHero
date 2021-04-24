using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSlide : BaseState
{
    public WallSlide(PlayerController controller, StateMachine stateMachine) : base(controller, stateMachine)
    {

    }

    public override void Enter()
    {
        
    }

    public override void Exit()
    {
        
    }

    public override void UpdateInput()
    {
        movementVector.y = -controller.WallSlideSpeed;

        controller.transform.position += movementVector * Time.deltaTime;
    }

    public override void UpdateLogic()
    {
        if (controller.IsGrounded)
        {
            stateMachine.ChangeState(EStateType.Idle);
        }
    }

    public override void UpdatePhysics()
    {
        
    }
}
