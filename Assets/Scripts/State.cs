using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{

    public abstract void EnterState(StateMachine stateMachine);

    public abstract void UpdateState(StateMachine stateMachine);

    public abstract void PhysicsUpdate(StateMachine stateMachine);

    public abstract void ExitState(StateMachine stateMachine);

    
   
}
