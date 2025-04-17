using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    InputAction moveAction;
    InputAction lookAction;
    InputAction jumpAction;

    Rigidbody2D playerRigidBody2D;
    SpriteRenderer playerSpriteRenderer;

    Vector2 playerMovement;
    Vector2 lookDirection;
    float playerDirection;

    public float playerMovementSpeed = 1;
    public float jumpSpeed = 5;
    private bool IsGrounded;

    private void Start()
    {
        playerRigidBody2D = GetComponent<Rigidbody2D>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();

        moveAction = InputSystem.actions.FindAction("Move");
        lookAction = InputSystem.actions.FindAction("Look");
        jumpAction = InputSystem.actions.FindAction("Jump");
    }

    private void Update()
    {
        JumpPlayer();

    }

    private void FixedUpdate()
    {
        MovePlayer();
        RotatePlayer();
    }

    public void MovePlayer()
    {
        playerMovement = moveAction.ReadValue<Vector2>() * playerMovementSpeed;

        playerRigidBody2D.AddForce(playerMovement);
    }

    public void RotatePlayer()
    {
        if (moveAction.ReadValue<Vector2>().x == -1)
        {
            playerSpriteRenderer.flipX = true;
        }
        else if (moveAction.ReadValue<Vector2>().x == 1)
        {
            playerSpriteRenderer.flipX = false;
        }
    }

    public void JumpPlayer()
    {
        if (jumpAction.IsPressed() && IsGrounded)
        {
            Vector2 jumpForce = new Vector2(0,jumpSpeed);

            playerRigidBody2D.AddForce(jumpForce);
            IsGrounded = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            IsGrounded = true;
        }
        else
        {
            IsGrounded = false;
        }
    }
}
