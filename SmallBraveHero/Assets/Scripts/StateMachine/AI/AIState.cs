using Code.StateMachine.AI.Actions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.StateMachine.AI.States
{
    [CreateAssetMenu(menuName ="AI/State")]
    public class AIState : ScriptableObject
    {
        [SerializeField] AIAction action;
        [SerializeField] Transition[] transitions;

        public void UpdateState(AIController controller)
        {
            if (controller.IsCharacterPerformingAction)
            {
                return;
            }

            DoActions(controller);

            CheckTransitions(controller);
        }

        private void DoActions(AIController controller)
        {
            action.Act(controller);          
        }

        private void CheckTransitions(AIController controller)
        {       
            for (int i = 0; i < transitions.Length; i++)
            {
                bool decisionSucceeded = transitions[i].Decision.Decide(controller);

                if (decisionSucceeded)
                {
                    controller.TransitionToState(transitions[i].TrueState);
                }
                else
                {
                    controller.TransitionToState(transitions[i].FalseState);
                }

            }
        }
    }
}