using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.StateMachine.AI.Decisions
{
    [CreateAssetMenu(menuName = "AI/Decisions/IsPlayerInMeleeRange")]
    public class IsPlayerInMeleeRange : AIDecision
    { 

        public override bool Decide(AIController controller)
        {
            return IsInMeleeRange(controller);
        }

        private bool IsInMeleeRange(AIController controller)
        {
            float distance = Vector2.Distance(controller.transform.position, controller.Target.transform.position);

            return distance <= controller.AttackRange;
        }


    }
}
