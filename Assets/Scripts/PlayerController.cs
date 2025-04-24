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

    public AudioSource walkingSound;
    public AudioSource jumpSound;
    public AudioSource crouchSound;
    public AudioSource landingSound;
    private const float landingSoundStartTime = 0.21f;

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
        PlayAudio();
    }

    private void FixedUpdate()
    {
        MovePlayer();
        RotatePlayer();

    }

    public void MovePlayer()
    {
        playerRigidBody2D.AddForce(playerMovement * playerMovementSpeed);

        if (jumpAction.IsPressed() && IsGrounded)
        {
            Vector2 jumpForce = new Vector2(0, jumpSpeed);

            playerRigidBody2D.AddForce(jumpForce);

            IsGrounded = false;
        }
    }

    public void RotatePlayer()
    {
        if (playerMovement.x == -1)
        {
            playerSpriteRenderer.flipX = true;
        }
        else if (playerMovement.x == 1)
        {
            playerSpriteRenderer.flipX = false;
        }
    }

    public void InputHandler()
    {
        playerMovement = moveAction.ReadValue<Vector2>();

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
        bool IsWalking = playerMovement != Vector2.zero;

        if(Input.GetKeyDown(KeyCode.S))
        {
            crouchSound.Play();
            walkingSound.volume = 0.6f;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            walkingSound.volume = 1;
        }

        if(IsWalking && IsGrounded && !walkingSound.isPlaying)
        {
            walkingSound.Play();
        }
        else if (walkingSound.isPlaying)
        {
                walkingSound.Stop();
        }

        if(Input.GetKeyDown(KeyCode.W) && !jumpSound.isPlaying)
        {
                jumpSound.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            IsGrounded = true;

            landingSound.time = landingSoundStartTime;
            landingSound.Play();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Object" && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(collision.gameObject);
            MainManager.objectCounter++;
        }
    }
}
