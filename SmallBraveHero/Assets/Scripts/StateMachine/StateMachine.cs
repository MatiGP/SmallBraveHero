using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class StateMachine
{
    private Dictionary<EStateType, BaseState> states;

    public BaseState CurrentState { get; private set; }

    public void Initialize()
    {
        states = new Dictionary<EStateType, BaseState>();       
    }

    public void ChangeState(EStateType stateTypeToChange)
    {
        CurrentState.Exit();
        CurrentState = states[stateTypeToChange];
        CurrentState.Enter();
    }

    public void AddState(EStateType stateType, BaseState state)
    {
        states.Add(stateType, state);
    }

    public void Start()
    {
        CurrentState = states.First().Value;
    }
}
