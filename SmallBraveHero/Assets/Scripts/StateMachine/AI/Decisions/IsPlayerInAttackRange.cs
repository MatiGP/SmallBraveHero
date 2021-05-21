using Code.StateMachine.AI;
using Code.StateMachine.AI.Decisions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.StateMachine.AI.Decisions
{
    [CreateAssetMenu(menuName = "AI/Decisions/IsPlayerInAttackRange")]
    public class IsPlayerInAttackRange : AIDecision
    {
        public override bool Decide(AIController controller)
        {
            return IsInAttackRange(controller);
        }

        bool IsInAttackRange(AIController controller)
        {
            float distance = Vector2.Distance(controller.transform.position, controller.Target.transform.position);

            return distance <= controller.AttackRange;           
        }
    }
}
