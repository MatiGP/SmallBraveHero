using Code.StateMachine.AI;
using Code.StateMachine.AI.Decisions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Decisions/IsPlayerInTauntRange")]
public class IsPlayerInTauntRange : AIDecision
{
    public override bool Decide(AIController controller)
    {
        PlayerController pc = LookForPlayer(controller);

        if(pc == null)
        {
            Debug.Log("No player");
            return false;
        }
        else
        {
            Debug.Log("Found Player!");
            controller.SetTarget(pc);
            return true;
        }


    }

    PlayerController LookForPlayer(AIController controller)
    {
        RaycastHit2D hit = Physics2D.Raycast(controller.transform.position, Vector2.right * controller.Direction, controller.TauntRange, LayerMask.GetMask("Player"));

        return hit.collider?.GetComponent<PlayerController>();      
    }

    
}
