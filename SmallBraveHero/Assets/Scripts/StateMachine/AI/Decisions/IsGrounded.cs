﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Code.StateMachine.AI.Decisions
{
    [CreateAssetMenu(menuName = "AI/Decisions/IsCharacterGrounded")]
    public class IsGrounded : AIDecision
    {
        public override bool Decide(AIController controller)
        {
            return controller.IsGrounded;
        }
    }
}
