using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRigidbody;
    [SerializeField] private float moveSpeed;

    [SerializeField] private Vector2 jump;
    [SerializeField] private float jumpForce = 5.0f;
    [SerializeField] private int baseJumpCount = 1;
    [SerializeField] private int jumpCount = 1;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        moveSpeed = GetComponent<Player>().moveSpeed;
        jump = new Vector2(0.0f, 1.0f);
        jumpCount = baseJumpCount;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    private void OnCollisionEnter()
    {
        
    }


    private void Move()
    {
        float inputX = Input.GetAxisRaw("Horizontal") *moveSpeed;

        Vector2 movement = new Vector2(inputX, 0.0f);
        movement *= Time.deltaTime;

        transform.Translate(movement);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) && jumpCount > 0)
        {
            playerRigidbody.AddForce(jump * jumpForce, ForceMode2D.Impulse);
            jumpCount--;
        }
        
        if(playerRigidbody.velocity.y == 0.0f)
        {
            jumpCount = baseJumpCount;
        }

    }
}
