using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.StateMachine.AI.Actions
{
    [CreateAssetMenu(menuName = "AI/Actions/ChaseThePlayer")]
    public class ChaseThePlayer : AIAction
    {
        public override void Act(AIController controller)
        {
            controller.AttackManager.UnlockCharacter();

            controller.CharacterAnimator.Play(controller.CharacterAnimPrefix + EAction.Run);

            int direction = GetPlayerDirection(controller);

            controller.transform.position += Vector3.right * controller.MoveSpeed * direction * Time.deltaTime;

            controller.SetDirection(direction);
            controller.FlipSprite();
        }

        public int GetPlayerDirection(AIController controller)
        {
            if (controller.Target.transform.position.x > controller.transform.position.x)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

    }
}
