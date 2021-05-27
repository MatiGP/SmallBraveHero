using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.StateMachine.AI.Decisions
{
    public class NoVar_IsUnderFist : AIDecision
    {
        public override bool Decide(AIController controller)
        {
           return controller.GetComponent<FistController>().IsUnderLeftFist();
        }
    }
}