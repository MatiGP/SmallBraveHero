using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.StateMachine.AI.Decisions
{
    [CreateAssetMenu(menuName = "AI/Decisions/IsPlayerTooClose")]
    public class IsPlayerTooClose : AIDecision
    {
        [SerializeField] private float distanceThreshold = 5f;

        public override bool Decide(AIController controller)
        {
            return CalculateDistance(controller) <= distanceThreshold;
        }

        private float CalculateDistance(AIController controller)
        {
            return Vector2.Distance(controller.transform.position, controller.Target.transform.position);
        }
    }
}
