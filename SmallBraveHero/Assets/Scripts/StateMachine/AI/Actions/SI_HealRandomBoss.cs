using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.StateMachine.AI.Actions
{
    [CreateAssetMenu(menuName = "AI/Actions/BOSSES/Spanish Inquisition/Heal Random Boss")]
    public class SI_HealRandomBoss : AIAction
    {
        [SerializeField] private float abilityCooldown = 7f;

        public override void Act(AIController controller)
        {
            controller.GetComponent<SI_Healer>().HealRandomBoss();
        }

        public override void PrepareAction(AIController controller)
        {
            controller.AttackManager.InitAbilityCooldown(abilityCooldown);
        }
    }
}
