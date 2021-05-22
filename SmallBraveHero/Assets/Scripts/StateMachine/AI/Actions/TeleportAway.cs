using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.StateMachine.AI.Actions
{
    [CreateAssetMenu(menuName = "AI/Actions/TeleportAway")]
    public class TeleportAway : AIAction
    {
        [SerializeField] private int teleportDistance = 10;

        public override void Act(AIController controller)
        {
            controller.transform.position += Vector3.right * FindClosetTeleportPoint(controller);
        }

        private float FindClosetTeleportPoint(AIController controller)
        {
            float newXPos = 0;

            for(int i = 0; i < teleportDistance; i++)
            {
                Vector2 rayOrigin = (Vector2)controller.transform.position + Vector2.right * controller.Direction * i;
                Vector2 rayDirection = rayOrigin - Vector2.down * 2;
                RaycastHit2D hit = Physics2D.Raycast(rayOrigin, rayDirection);
                if (hit)
                {
                    newXPos = hit.point.x;
                }
                else
                {
                    break;
                }
            }

            return newXPos;
        }
    }
}
