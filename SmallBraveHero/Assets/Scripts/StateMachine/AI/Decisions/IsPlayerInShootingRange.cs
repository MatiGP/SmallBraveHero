using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.StateMachine.AI.Decisions
{
    [CreateAssetMenu(menuName = "AI/Decisions/IsPlayerInShootingRange")]
    public class IsPlayerInShootingRange : AIDecision
    {
        [SerializeField] private float shootingRange = 5f;

        public override bool Decide(AIController controller)
        {
            return IsInShootingRange(controller);
        }

        private bool IsInShootingRange(AIController controller)
        {
            float distance = Vector2.Distance(controller.transform.position, controller.Target.transform.position);

            return distance <= shootingRange;
        }
    }
}
