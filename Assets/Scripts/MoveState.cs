using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    Player player;
    public override void EnterState(StateMachine stateMachine)
    {
        //Debug.Log("Entering MoveState");
        player = stateMachine.GetComponent<Player>();
    }

    public override void UpdateState(StateMachine stateMachine)
    {
        if(Input.GetKeyDown(KeyCode.Space) && player.GetComponent<Rigidbody2D>().velocity.y == 0)
        {
            stateMachine.SetState(new JumpState());
        }
    }

    public override void PhysicsUpdate(StateMachine stateMachine)
    {
        float inputX = Input.GetAxisRaw("Horizontal") * player.moveSpeed;

        Vector2 movement = new Vector2(inputX, 0.0f);
        movement *= Time.deltaTime;

        player.transform.Translate(movement);
    }

    public override void ExitState(StateMachine stateMachine)
    {
        //Debug.Log("Exiting MoveState");
    }
}
