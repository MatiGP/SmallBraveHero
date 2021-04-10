using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.StateMachine.AI.Actions
{
    [CreateAssetMenu(menuName = "AI/Actions/Look For Player")]
    public class LookForThePlayer : AIAction
    {
        [SerializeField] float lookDelay;

        public override void Act(AIController controller)
        {
            Debug.Log("Looking for player");
        }

        
    }
}
