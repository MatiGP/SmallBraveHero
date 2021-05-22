using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.StateMachine.AI.Actions
{
    [CreateAssetMenu(menuName = "AI/Actions/AttackThePlayer/Melee")]
    public class AttackInMelee : AIAction
    {
        [HideInInspector()]
        public bool hasMultipleAttacks;
        [HideInInspector()]
        public int attackCount;

        public override void Act(AIController controller)
        {
            if (hasMultipleAttacks)
            {
                controller.AttackManager.DoAttack(controller.CharacterAnimPrefix + EAction.MeleeAttack + Random.Range(0, attackCount));
                Debug.Log($"Attack name : {controller.CharacterAnimPrefix + EAction.MeleeAttack + Random.Range(0, attackCount)}");
            }
            else
            {
                controller.CharacterAnimator.Play(controller.CharacterAnimPrefix + EAction.MeleeAttack + "0");
            }
        }
    }
}
