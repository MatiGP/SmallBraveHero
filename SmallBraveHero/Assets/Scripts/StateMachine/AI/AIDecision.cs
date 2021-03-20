using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIDecision : ScriptableObject
{
    public int DecisionValue { get => decisionValue; }
    [SerializeField] int decisionValue;

    public abstract bool Decide(AIController controller);
}
