using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    public abstract void Enter();
    public abstract void Exit();
    public abstract void UpdateInput();
    public abstract void UpdateLogic();
    public abstract void UpdatePhysics();
}
