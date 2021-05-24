using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.StateMachine.AI.Decisions
{
    [CreateAssetMenu(menuName = "AI/Decisions/ShouldCastAbility")]
    public class ShouldCastAnAbility : AIDecision
    {
        [SerializeField] private float chanceToCastAbility = 0.05f;

        public override bool Decide(AIController controller)
        {
            float chance = Random.value;

            return (chance < chanceToCastAbility) && (controller.AttackManager.CurrentAbilityCooldown <= 0);
        }     
    }
}