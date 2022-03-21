using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStateMachine : StateMachine
{
    GameObject playerObject;
    private void Start()
    {
        playerObject = GetComponent<GameObject>();
        InitializeState(new IdleState());
    }

    public void Update()
    {
        currentState.UpdateState(this);
    }

    public void FixedUpdate()
    {
        currentState.PhysicsUpdate(this);
    }

    public override void InitializeState(State state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
    public override void SetState(State state)
    {
        currentState.ExitState(this);

        currentState = state;

        currentState.EnterState(this);
    }
    
    
}
