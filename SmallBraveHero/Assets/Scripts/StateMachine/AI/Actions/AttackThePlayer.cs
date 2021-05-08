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
        public int projectileID;
        [HideInInspector()]
        public bool hasMultipleAttacks;
        [HideInInspector()]
        public int attackCount;

        public override void Act(AIController controller)
        {
            Debug.Log($"Attacking :{controller.Target.name}");

            controller.AttackManager.SetDirection(controller.Direction);

            Debug.Log($"Setting attack direction {controller.Direction} ");

            if (controller.AttackManager.IsAttackCompleted)
            {
                Debug.Log("Other Attacking Action is in progress");
                return;
            }

            Debug.Log(isRanged);

            if (isRanged)
            {
                controller.AttackManager.DoAttack(controller.CharacterAnimPrefix + EAction.RangedAttack + "0");
                Debug.Log($"Ranged Attack name : {controller.CharacterAnimPrefix + EAction.RangedAttack + "0"}");
            }
            else
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


}
