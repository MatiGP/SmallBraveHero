using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.StateMachine.AI.Actions
{
    [CreateAssetMenu(menuName = "AI/Actions/Do Nothing")]
    public class DoNothing : AIAction
    {
        public override void Act(AIController controller)
        {
            controller.CharacterAnimator.Play(controller.CharacterAnimPrefix + EAction.Idle);
        }

        public override void PrepareAction(AIController controller)
        {
            
        }
    }
}
