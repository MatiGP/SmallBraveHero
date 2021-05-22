using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.StateMachine.AI.Actions
{
    [CreateAssetMenu(menuName = "AI/Actions/Dash")]
    public class Dash : AIAction
    {
        [SerializeField] private float dashSpeed = 15f;

        public override void Act(AIController controller)
        {
            controller.CharacterAnimator.Play(controller.CharacterAnimPrefix + EAction.Dash);

            controller.transform.position += CalculateMovementVector(controller);

        }

        private Vector3 CalculateMovementVector(AIController controller)
        {
            if (controller.IsTouchingRightWall && controller.Direction > 0)
            {
                return Vector3.zero;
            }

            if (controller.IsTouchingLeftWall && controller.Direction < 0)
            {
                return Vector3.zero;
            }

            if (controller.ReachedEndOfPlatform)
            {
                return Vector3.zero;
            }

            return Vector3.right * dashSpeed * controller.Direction * Time.deltaTime;
        }


    }
}
