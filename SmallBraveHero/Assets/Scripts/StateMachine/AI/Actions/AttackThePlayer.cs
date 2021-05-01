using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Code.StateMachine.AI.Actions
{
    [CreateAssetMenu(menuName = "AI/Actions/AttackThePlayer")]
    public class AttackThePlayer : AIAction
    { 
        [HideInInspector()]
        public bool isRanged;
        [HideInInspector()]
        public bool hasMultipleAttacks;
        [HideInInspector()]
        public int attackCount;

        public override void Act(AIController controller)
        {
            Debug.Log($"Attacking :{controller.Target.name}");

            if (isRanged)
            {
                //TODO: IMPLEMENT ME PLS
            }
            else
            {
                if (hasMultipleAttacks)
                {
                    controller.CharacterAnimator.Play(controller.CharacterAnimPrefix + EAction.MeleeAttack + Random.Range(0, attackCount+1));
                }
            }
            
        }
    }


}
