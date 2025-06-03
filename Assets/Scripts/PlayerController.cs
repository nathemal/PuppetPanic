using System.Collections;
using Unity.VisualScripting;
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

    public SpriteRenderer playerRenderer;
    public Sprite idleSprite;
    public Sprite walkingSprite;
    public Sprite jumpSprite;
    public Sprite crouchSprite;
    public Sprite pickUpSprite;
    public Sprite pushSprite;
    public Sprite splashSprite;
    public Transform player;
    public Vector3 offset = new Vector3(1, 0, 0);

    public Animator animator;
    private float moveInput;
    float timer;

    Vector2 playerMovement;

    public float playerMovementSpeed = 1;
    public float jumpSpeed = 5;
    public float pushForce = 2.0f;
    public static bool isGrounded;
    private bool shouldJump;

    public AudioSource walkingSound;
    public AudioSource jumpSound;
    public AudioSource crouchSound;
    public AudioSource landingSound;
    private const float landingSoundStartTime = 0.21f;

    private int layerDefault;
    private int layerJump;
    private float lastY;
    public GameObject interactPromt;

    private PlayerHealth playerHealthScript;
    public GameObject GameOverScreen;

    private void Start()
    {
        playerRigidBody2D = GetComponent<Rigidbody2D>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
        playerCollider2D = GetComponent<BoxCollider2D>();
        playerHealthScript = GetComponent<PlayerHealth>();

        layerDefault = LayerMask.NameToLayer("Player");
        layerJump = LayerMask.NameToLayer("NoCollision");
        lastY = transform.position.y;

        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        crouchAction = InputSystem.actions.FindAction("Crouch");
    }

    private void Update()
    {
        InputHandler();
        PlayAudio();
        DeadPlayer();
    }

    private void FixedUpdate()
    {
        MovePlayer();
        RotatePlayer();
        JumpLayerChange();
    }

    public void InputHandler()
    {
        playerMovement = moveAction.ReadValue<Vector2>();

        Vector2 colliderSize = new Vector2(2.6f, 7f);
        Vector2 colliderOffset = new Vector2(0, 3.6f);

        if (crouchAction.IsPressed())
        {
            animator.enabled = false;
            playerCollider2D.size = new Vector2(playerCollider2D.size.x, 3.5f);
            playerCollider2D.offset = new Vector2(playerCollider2D.offset.x, 1.8f);
            playerSpriteRenderer.sprite = crouchSprite;
        }
        else
        {
            playerCollider2D.size = colliderSize;
            playerCollider2D.offset = colliderOffset;
        }

        if(jumpAction.IsPressed() && isGrounded)
        {
            animator.enabled = false;
            playerSpriteRenderer.sprite = jumpSprite;
            shouldJump = true;
            isGrounded = false;
        }

        if(!isGrounded)
        {
            timer += Time.deltaTime;

            if(timer >= 0.3)
            {
                timer = 0;
                animator.enabled = false;
                playerSpriteRenderer.sprite = jumpSprite;
            }
        }

        moveInput = Input.GetAxisRaw("Horizontal");

        if (moveAction.IsPressed() && isGrounded && !Input.GetKey(KeyCode.E) && !crouchAction.IsInProgress())
        {
            animator.enabled = true;
            animator.SetBool("Walking", true);
            animator.SetFloat("Speed", Mathf.Abs(moveInput));
        }

        if(moveAction.WasReleasedThisFrame())
        {
            animator.SetBool("Walking", false);
            animator.SetFloat("Speed", Mathf.Abs(moveInput));
        }
    }

    public void PlayAudio()
    {
        bool isWalking = playerMovement != Vector2.zero;

        if (Input.GetKeyDown(KeyCode.S))
        {
            crouchSound.Play();
            walkingSound.volume = 0.6f;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            walkingSound.volume = 1;
        }

        if (isWalking && isGrounded && !walkingSound.isPlaying)
        {
            walkingSound.Play();
        }
        else if (walkingSound.isPlaying)
        {
            walkingSound.Stop();
        }

        if (Input.GetKeyDown(KeyCode.W) && !jumpSound.isPlaying)
        {
            jumpSound.Play();
        }
    }

    public void MovePlayer()
    {
        playerRigidBody2D.AddForce(playerMovement * playerMovementSpeed);

        if (shouldJump)
        {
            Vector2 jumpForce = new Vector2(0, jumpSpeed);

            playerRigidBody2D.AddForce(jumpForce);

            shouldJump = false;
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

    public void JumpLayerChange()
    {
        float currentY = transform.position.y;

        if (!isGrounded)
        {
            if (currentY > lastY)
            {
                gameObject.layer = layerJump;
            }
            else
            {
                gameObject.layer = layerDefault;
            }
        }

        lastY = currentY;
    }

    public void DeadPlayer()
    {
        if (PlayerHealth.isAlive == false)
        {
            playerSpriteRenderer.sprite = splashSprite;
            StartCoroutine(WaitForFunction());
        }
    }

    IEnumerator WaitForFunction()
    {
        yield return new WaitForSeconds(3);
        GameOverScreen.SetActive(true);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground" || collision.gameObject.tag == "PushableObject")
        {
            isGrounded = true;

            landingSound.time = landingSoundStartTime;
            landingSound.Play();

            playerSpriteRenderer.sprite = idleSprite;
        }

        if(collision.gameObject.tag == "PushableObject")
        {
            interactPromt.SetActive(true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "PushableObject")
        {
            interactPromt.SetActive(false);
        }

        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Object" && Input.GetKey(KeyCode.E))
        {
            animator.enabled = false;
            playerSpriteRenderer.sprite = pickUpSprite;
            Destroy(collision.gameObject);
            MainManager.objectCounter++;
        }

        if (collision.gameObject.tag == "PushableObject" && Input.GetKey(KeyCode.E))
        {
            animator.enabled = false;
            playerSpriteRenderer.sprite = pushSprite;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Object" || collision.gameObject.tag == "PushableObject")
        {
            interactPromt.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Object" || collision.gameObject.tag == "PushableObject")
        {
            interactPromt.SetActive(false);
        }
    }
}
