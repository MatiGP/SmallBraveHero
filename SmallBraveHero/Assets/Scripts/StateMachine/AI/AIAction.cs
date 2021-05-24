using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.StateMachine.AI.Actions
{
    public abstract class AIAction : ScriptableObject
    {
        public abstract void PrepareAction(AIController controller);
        public abstract void Act(AIController controller);
    }

    enum EAction { Idle, Run, Death, MeleeAttack, RangedAttack, Dash }
}
