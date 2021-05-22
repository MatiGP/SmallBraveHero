using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.StateMachine.AI.Actions
{
    [CreateAssetMenu(menuName = "AI/Actions/HealUp")]
    public class HealUp : AIAction
    {
        [SerializeField] private int healAmount;

        public override void Act(AIController controller)
        {
            controller.CharacterHealth.Heal(healAmount);
        }
    }
}