using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.StateMachine.AI.Actions
{
    [CreateAssetMenu(menuName = "AI/Actions/Jump")]
    public class Jump : AIAction
    {
        public override void Act(AIController controller)
        {
            controller.transform.position += CalculateJumpVector(controller);
        }

        public override void PrepareAction(AIController controller)
        {
            
        }

        private Vector3 CalculateJumpVector(AIController controller)
        {
            return Vector3.up * controller.JumpHeight * Time.deltaTime;
        }
    }
}
