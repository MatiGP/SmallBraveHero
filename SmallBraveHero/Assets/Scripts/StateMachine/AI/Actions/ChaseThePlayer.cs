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
            

            controller.transform.position += Vector3.right * controller.MoveSpeed * Time.deltaTime;

        }


    }
}
