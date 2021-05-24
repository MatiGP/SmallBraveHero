using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Code.StateMachine.AI.Actions
{
    [CreateAssetMenu(menuName = "AI/Actions/Fall")]
    public class Fall : AIAction
    {
        public override void Act(AIController controller)
        {
            controller.transform.position += Vector3.down * controller.Gravity * Time.deltaTime;
        }

        public override void PrepareAction(AIController controller)
        {
            
        }
    }
}
