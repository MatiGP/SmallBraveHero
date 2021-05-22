using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.StateMachine.AI.Actions
{
    [CreateAssetMenu(menuName = "AI/Actions/AttackThePlayer/Ranged")]
    public class AttackInRanged : AIAction
    {
        public override void Act(AIController controller)
        {
            if (!controller.AttackManager.IsAttackCompleted)
            {
                Debug.Log("Other Attacking Action is in progress");
                return;
            }

            Debug.Log($"Attacking :{controller.Target.name} with ranged attack");

            controller.AttackManager.SetDirection(controller.Direction);

            Debug.Log($"Setting attack direction {controller.Direction} ");
            
            controller.AttackManager.DoAttack(controller.CharacterAnimPrefix + EAction.RangedAttack + "0");
            Debug.Log($"Ranged Attack name : {controller.CharacterAnimPrefix + EAction.RangedAttack + "0"}");
            
        }     
    }
}
