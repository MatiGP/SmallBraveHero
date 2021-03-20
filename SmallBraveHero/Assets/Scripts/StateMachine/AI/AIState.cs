using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIState : ScriptableObject
{
    public abstract void Enter(AIController controller);
    public abstract void Exit(AIController controller);
    public abstract void UpdateInput(AIController controller);
    public abstract void UpdateLogic(AIController controller);
    public abstract void UpdatePhysics(AIController controller);
}
