using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : BaseState
{
    public PatrolState(CharacterController controller, StateMachine stateMachine) : base(controller, stateMachine)
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
        movementVector.x = controller.Direction * controller.MoveSpeed;

        controller.transform.position += movementVector * Time.deltaTime;
    }

    public override void UpdateLogic()
    {
        if(controller.IsTouchingRightWall && controller.Direction == 1)
        {
            controller.ChangeDirection();
            controller.FlipSprite();
        }
        else if(controller.IsTouchingLeftWall && controller.Direction == -1)
        {
            controller.ChangeDirection();
            controller.FlipSprite();
        }


    }

    public override void UpdatePhysics()
    {
        
    }
}
