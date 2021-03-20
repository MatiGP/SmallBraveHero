using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition
{
    [SerializeField] AIDecision decision;

    [SerializeField] AIState trueState;
    [SerializeField] AIState falseState;
}
