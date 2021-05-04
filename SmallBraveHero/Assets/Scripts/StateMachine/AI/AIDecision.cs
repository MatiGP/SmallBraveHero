using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.StateMachine.AI.Decisions
{
    public abstract class AIDecision : ScriptableObject
    {
        public abstract bool Decide(AIController controller);
    }
}
