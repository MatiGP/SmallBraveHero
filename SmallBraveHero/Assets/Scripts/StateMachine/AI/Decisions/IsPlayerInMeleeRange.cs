using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.StateMachine.AI.Decisions
{
    [CreateAssetMenu(menuName = "AI/Decisions/IsPlayerInMeleeRange")]
    public class IsPlayerInMeleeRange : AIDecision
    {
        [SerializeField] private float meleeRange = 0.5f;

        public override bool Decide(AIController controller)
        {
            return IsInMeleeRange(controller);
        }

        private bool IsInMeleeRange(AIController controller)
        {
            float distance = Vector2.Distance(controller.transform.position, controller.Target.transform.position);

            return distance <= meleeRange;
        }


    }
}
