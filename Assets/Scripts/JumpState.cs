using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : State
{
    Player player;
    int jumpCount;
    public override void EnterState(StateMachine stateMachine)
    {
        //Debug.Log("Entering JumpState");
        player = stateMachine.GetComponent<Player>();

        player.GetComponent<Rigidbody2D>().AddForce(player.jump * player.jumpForce, ForceMode2D.Impulse);
        jumpCount = player.jumpCount;
        Debug.Log(jumpCount);
        jumpCount--;
        Debug.Log(jumpCount);
    }

    public override void UpdateState(StateMachine stateMachine)
    {
        if (player.GetComponent<Rigidbody2D>().velocity.y == 0.0f)
        {
            stateMachine.SetState(new IdleState());
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount > 0)
        {
            player.GetComponent<Rigidbody2D>().AddForce(player.jump * player.jumpForce, ForceMode2D.Impulse);
            Debug.Log(jumpCount);
            jumpCount--;
            Debug.Log(jumpCount);
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
        //Debug.Log("Exiting JumpState");
    }
}
