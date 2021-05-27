using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.StateMachine.AI.Actions
{
    [CreateAssetMenu(menuName = "AI/Actions/BOSSES/Spanish Inquisition/Teleport Away - Healer")]
    public class SI_Healer_TeleportAway : AIAction
    {
        public override void Act(AIController controller)
        {


            controller.GetComponent<SI_Healer>().TeleportAway();
        }

        public override void PrepareAction(AIController controller)
        {
           
        }
    }
}
