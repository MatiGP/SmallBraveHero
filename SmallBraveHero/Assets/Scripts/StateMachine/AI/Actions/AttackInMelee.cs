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
            if (!controller.AttackManager.IsAttackCompleted)
            {
                Debug.Log("Other Attacking Action is in progress");
                return;
            }

            if (hasMultipleAttacks)
            {
                int attackIndex = Random.Range(0, attackCount);

                controller.AttackManager.DoAttack(controller.CharacterAnimPrefix + EAction.MeleeAttack + attackIndex);

                Debug.Log("Attaking with index : " + attackIndex);
            }
            else
            {
                controller.CharacterAnimator.Play(controller.CharacterAnimPrefix + EAction.MeleeAttack + "0");
            }
        }

        public override void PrepareAction(AIController controller)
        {
            
        }
    }
}
