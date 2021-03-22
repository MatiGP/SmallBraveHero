using Code.StateMachine.AI.Decisions;
using Code.StateMachine.AI.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.StateMachine.AI
{
    [System.Serializable]
    public class Transition
    {
        public AIDecision Decision { get => decision; }
        [SerializeField] AIDecision decision;


        [SerializeField] AIState trueState; // if decision is true;
        public AIState TrueState { get => trueState; }
        [SerializeField] AIState falseState; // if desision is false;
        public AIState FalseState { get => falseState; }
    }
}
