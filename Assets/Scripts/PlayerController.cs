using Microsoft.Win32.SafeHandles;
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

    public Transform player;
    public Vector3 offset = new Vector3(1, 0, 0);

    Vector2 playerMovement;

    public float playerMovementSpeed = 1;
    public float jumpSpeed = 5;
    public float pushForce = 2.0f;
    private bool IsGrounded;

    public AudioSource WalkingSound;
    public AudioSource JumpSound;
    public AudioSource CrouchSound;
    public AudioSource LandingSound;
    private const float LandingSoundStartTime = 0.21f;

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
        InputHandler();
        RotatePlayer();
        PlayAudio();
    }

    private void FixedUpdate()
    {
        MovePlayer();
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

    public void InputHandler()
    {
        if (jumpAction.IsPressed() && IsGrounded)
        {
            Vector2 jumpForce = new Vector2(0, jumpSpeed);

            playerRigidBody2D.AddForce(jumpForce);

            IsGrounded = false;
        }

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
        Vector2 movementInput = moveAction.ReadValue<Vector2>();

        bool IsWalking = movementInput != Vector2.zero;

        if(Input.GetKeyDown(KeyCode.S))
        {
            CrouchSound.Play();
            WalkingSound.volume = 0.6f;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            WalkingSound.volume = 1;
        }

        if(IsWalking && IsGrounded)
        {
            if(!WalkingSound.isPlaying)
            {
                WalkingSound.Play();
            }
        }
        else
        {
            if (WalkingSound.isPlaying)
            {
                WalkingSound.Stop();
            }
        }

        if(Input.GetKeyDown(KeyCode.W))
        {
            if (!JumpSound.isPlaying)
            {
                JumpSound.Play();
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            IsGrounded = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            LandingSound.time = LandingSoundStartTime;
            LandingSound.Play();
        }

        if (collision.gameObject.tag == "PushableObject")
        {
            Rigidbody2D objectBody = collision.collider.attachedRigidbody;

            if (collision.contacts[0].normal.y > 10f)
            {
                objectBody.linearVelocity = Vector2.zero;
                return;
            }

            Vector2 pushDirection = new Vector2(collision.relativeVelocity.x, 0);
            objectBody.linearVelocity = pushDirection * pushForce;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Object" && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(collision.gameObject);
            MainManager.objectCounter++;
        }

        if (collision.gameObject.tag == "Ground")
        {
            IsGrounded = true;
        }
    }
}
