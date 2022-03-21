using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    private float horizontalInput;
    private float verticalInput;

    public override void EnterState(StateMachine stateMachine)
    {
        //Debug.Log("Entering IdleState");
        horizontalInput = verticalInput = 0.0f;
        
    }

    public override void UpdateState(StateMachine stateMachine)
    {
        //Debug.Log("In Idle State");
        if (Input.GetAxis("Horizontal") != 0)
        {
            stateMachine.SetState(new MoveState());
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.SetState(new JumpState());
        }
    }

    public override void PhysicsUpdate(StateMachine stateMachine)
    {
        
    }

    public override void ExitState(StateMachine stateMachine)
    {
        //Debug.Log("Exiting Idle State");
    }
}
