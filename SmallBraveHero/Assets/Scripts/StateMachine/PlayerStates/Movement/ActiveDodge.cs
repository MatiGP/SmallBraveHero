using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveDodge : BaseState
{
    float direction;
    float currentDodgeDuration;

    public ActiveDodge(PlayerController controller, StateMachine stateMachine) : base(controller, stateMachine)
    {        
    }

    public override void Enter()
    {
        movementVector = Vector3.zero;
        direction = controller.IsFacingRight ? -1 : 1;
        currentDodgeDuration = 0;
    }

    public override void Exit()
    {
        movementVector = Vector3.zero;
    }

    public override void UpdateInput()
    {
        movementVector.x = controller.ActiveDodgeSpeed * direction;

        controller.transform.position += movementVector * Time.deltaTime;
    }

    public override void UpdateLogic()
    {
        currentDodgeDuration += Time.deltaTime;

        if(currentDodgeDuration >= controller.ActiveDodgeDuration)
        {
            stateMachine.ChangeState(EStateType.Run);
        }
    }

    public override void UpdatePhysics()
    {
        
    }

    
}
