using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Code.StateMachine.AI.Actions
{
    [CreateAssetMenu(menuName = "AI/Actions/AttackThePlayer")]
    public class AttackThePlayer : AIAction
    {
        public override void Act(AIController controller)
        {
            Debug.Log($"Attacking :{controller.Target.name}");

            controller.CharacterAnimator.Play(controller.CharacterAnimPrefix + EAction.MeleeAttack);
        }
    }
}
