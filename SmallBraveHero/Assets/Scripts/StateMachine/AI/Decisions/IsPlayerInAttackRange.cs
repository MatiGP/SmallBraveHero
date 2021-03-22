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
            return true;
        }
    }
}
