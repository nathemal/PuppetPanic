using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    InputAction moveAction;
    InputAction jumpAction;
    InputAction crouchAction;

    Rigidbody2D playerRigidBody2D;
    SpriteRenderer playerSpriteRenderer;
    BoxCollider2D playerCollider2D;

    Vector2 playerMovement;

    public float playerMovementSpeed = 1;
    public float jumpSpeed = 5;
    private bool IsGrounded;

    public AudioSource WalkingSound;
    public AudioSource JumpSound;
    public AudioSource CrouchSound;

    private void Start()
    {
        playerRigidBody2D = GetComponent<Rigidbody2D>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
        playerCollider2D = GetComponent<BoxCollider2D>();

        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        crouchAction = InputSystem.actions.FindAction("Crouch");
    }

    private void Update()
    {
        JumpPlayer();
        CrouchPlayer();
    }

    private void FixedUpdate()
    {
        MovePlayer();
        RotatePlayer();
        PlayAudio();
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

            JumpSound.Play();
        }
    }

    public void CrouchPlayer()
    {
        Vector2 colliderSize = new Vector2(1.35f, 4.29f);
        Vector2 colliderOffset = new Vector2(0, 0);

        if (crouchAction.IsPressed())
        {
            playerCollider2D.size = new Vector2(playerCollider2D.size.x, 2);
            playerCollider2D.offset = new Vector2(playerCollider2D.offset.x, -1.15f);
        }
        else
        {
            playerCollider2D.size = colliderSize;
            playerCollider2D.offset = colliderOffset;
        }
    }

    public void PlayAudio()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            CrouchSound.Play();
        }
        
        while(moveAction.IsInProgress() && IsGrounded)
        {
            WalkingSound.Play();
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
