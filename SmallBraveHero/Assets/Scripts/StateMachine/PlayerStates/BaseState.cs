using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    protected Vector3 movementVector;
    protected PlayerController controller;
    protected StateMachine stateMachine;

    public BaseState(PlayerController controller, StateMachine stateMachine)
    {
        this.controller = controller;
        this.stateMachine = stateMachine;
    }

    public abstract void Enter();
    public abstract void Exit();
    public abstract void UpdateInput();
    public abstract void UpdateLogic();
    public abstract void UpdatePhysics();
}
