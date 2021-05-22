using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.StateMachine.AI.Actions
{
    public class Die : AIAction
    {
        public override void Act(AIController controller)
        {
            Debug.Log("DIE MORTAL!");
            controller.gameObject.SetActive(false);
        }
    }
}
