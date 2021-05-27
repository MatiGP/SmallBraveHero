using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.StateMachine.AI.Actions
{
    [CreateAssetMenu(menuName = "AI/Actions/BOSSES/No'Var/TrackingFist")]
    public class NoVar_TrackingFist : AIAction
    {
        [SerializeField] private float trackingSpeed = 2f;

        private FistController fistController = null;

        public override void Act(AIController controller)
        {
            fistController.transform.position += new Vector3(TrackingPos(controller), 0, 0);
        }

        public override void PrepareAction(AIController controller)
        {
            fistController = controller.GetComponent<FistController>();
        }

        public float TrackingPos(AIController controller)
        {
            Vector2 trackingVector = Vector2.MoveTowards(fistController.LeftFist.transform.position, 
                controller.Target.transform.position, trackingSpeed);

            return trackingVector.x;
        }
    }
}
