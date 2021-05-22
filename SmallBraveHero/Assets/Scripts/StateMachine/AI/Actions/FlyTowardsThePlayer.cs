using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.StateMachine.AI.Actions
{
    [CreateAssetMenu(menuName = "AI/Actions/FlyTowardsThePlayer")]
    public class FlyTowardsThePlayer : AIAction
    {
        [SerializeField] private float stoppingDistance = 4f;
        [SerializeField] private float speed = 9f;

        public override void Act(AIController controller)
        {
            Vector2 enemyPos = controller.transform.position;
            Vector2 targetPosition = controller.Target.transform.position;

            controller.transform.position += Vector3.MoveTowards(enemyPos, targetPosition, speed * Time.deltaTime);
        }
    }
}
