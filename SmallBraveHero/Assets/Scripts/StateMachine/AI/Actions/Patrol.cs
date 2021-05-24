using Code.StateMachine.AI.Actions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.StateMachine.AI.Actions
{
    [CreateAssetMenu(menuName = "AI/Actions/Patrol")]
    public class Patrol : AIAction
    {      
        public override void Act(AIController controller)
        {
            controller.CharacterAnimator.Play(controller.CharacterAnimPrefix + EAction.Run);

            controller.transform.position += CalculateMovementVector(controller);
        }

        public override void PrepareAction(AIController controller)
        {
            
        }

        private Vector3 CalculateMovementVector(AIController controller)
        {           
            if(controller.IsTouchingRightWall && controller.Direction > 0)
            {
                controller.ChangeDirection();
                controller.FlipSprite();
            }

            if (controller.IsTouchingLeftWall && controller.Direction < 0)
            {
                controller.ChangeDirection();
                controller.FlipSprite();
            }

            if (controller.ReachedEndOfPlatform)
            {
                controller.ChangeDirection();
                controller.FlipSprite();
            }

            return Vector3.right * controller.PatrolMoveSpeed * controller.Direction * Time.deltaTime;
        }
        
    }  
}

