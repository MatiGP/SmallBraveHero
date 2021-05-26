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

            CheckTransitions(controller);

            DoActions(controller);

            
        }

        private void DoActions(AIController controller)
        {
            action.Act(controller);          
        }

        private void CheckTransitions(AIController controller)
        {       
            for (int i = 0; i < transitions.Length; i++)
            {
                bool decisionSucceeded =
                    transitions[i].Negate ? !transitions[i].Decision.Decide(controller) : transitions[i].Decision.Decide(controller);



                Debug.Log($"Decision succeeded: {decisionSucceeded} for {transitions[i].TrueState}");

                if (decisionSucceeded)
                {
                    transitions[i].TrueState.action.PrepareAction(controller);
                    controller.TransitionToState(transitions[i].TrueState);
                }               
            }

            controller.TransitionToState(controller.RemainInState);
        }
    }
}