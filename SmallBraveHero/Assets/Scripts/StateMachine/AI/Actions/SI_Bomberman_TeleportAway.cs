using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.StateMachine.AI.Actions
{
    [CreateAssetMenu(menuName = "AI/Actions/BOSSES/Spanish Inquisition/Teleport Away - Bomberman")]
    public class SI_Bomberman_TeleportAway : AIAction
    {
        public override void Act(AIController controller)
        {
            controller.GetComponent<SI_Bomberman>().TeleportToRandomPoint();
            controller.SetDirection(GetPlayerDirection(controller));
        }

        public override void PrepareAction(AIController controller)
        {
            
        }

        private int GetPlayerDirection(AIController controller)
        {
            if (controller.Target.transform.position.x > controller.transform.position.x)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }
}
