using UnityEngine;
using UnityEngine.InputSystem;

public class PushPullObject : MonoBehaviour
{
    public static PushPullObject instance;

    public float Speed = 5f;

    public AudioSource pushPullSound;

    private RigidbodyType2D defaultBodyType;
    private Rigidbody2D rb;
    private Vector2 lastPlayerPos;
    private Transform player;
    
    public bool isInteracting = false;
    private bool inRange = false;
    private bool isGrounded = true;

    InputAction interactAction;

    private int defaultLayer;
    private int noCollisionLayer;
    private int lastLayer;



    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        interactAction = InputSystem.actions.FindAction("Interact");

        rb = GetComponent<Rigidbody2D>();
        
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        
        defaultBodyType = rb.bodyType;

        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

        defaultLayer = LayerMask.NameToLayer("Obstacle");
        noCollisionLayer = LayerMask.NameToLayer("NoCollision");
        lastLayer = gameObject.layer;
    }

    void Update()
    {
        if (inRange == true && Input.GetKeyDown(KeyCode.E))
        {
            isInteracting = !isInteracting;

            if (isInteracting)
            {
                lastPlayerPos = player.position;
            }
            else
            {
                rb.linearVelocity = Vector2.zero;
            }
        }

        if (Failsave.triggered)
        {
            Failsafe();
        }
    }

    void FixedUpdate()
    {
        if (!isInteracting)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

            if (isGrounded)
            {
                rb.constraints |= RigidbodyConstraints2D.FreezePositionY; 
            }
                
            return;
        }

        if (isGrounded)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        Vector2 currentPlayerPos = player.position;
        Vector2 playerMovement = currentPlayerPos - lastPlayerPos;

        if (IsPushingTowardObject(playerMovement))
        {
            rb.MovePosition(rb.position + playerMovement);
        }

        if (playerMovement.sqrMagnitude > 0.0001f)
        {
            if (!pushPullSound.isPlaying)
                pushPullSound.Play();
        }
        else
        {
            if (pushPullSound.isPlaying)
                pushPullSound.Stop();
        }

        lastPlayerPos = currentPlayerPos;
    }

    private bool IsPushingTowardObject(Vector2 playerMovement)
    {
        float directionToObject = Mathf.Sign(transform.position.x - player.position.x);
        float playerInputDirection = Mathf.Sign(playerMovement.x);
        return directionToObject == playerInputDirection && playerMovement.x != 0f;
    }

    public void Failsafe()
    {
        if (!isGrounded) return;

        isGrounded = false;
        gameObject.layer = LayerMask.NameToLayer("NoCollision");

        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb.bodyType = RigidbodyType2D.Dynamic;

        isInteracting = false;

        if (pushPullSound != null && pushPullSound.isPlaying)
        {
            pushPullSound.Stop();
        }

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            PlayerController pc = player.GetComponent<PlayerController>();

            if (pc != null)
            {
                pc.StartCoroutine(pc.FallingSequence());
            }
        }

        ChangeAfterFall caf = GetComponent<ChangeAfterFall>();
        if (caf != null)
        {
            caf.FailsafeFall();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = true;
            player = other.transform;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = false;
            if (isInteracting == true)
            {
                isInteracting = false;

                if (pushPullSound.isPlaying)
                {
                    pushPullSound.Stop();
                }

                rb.bodyType = defaultBodyType;
            }

            player = null;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground") && isGrounded == false)
        {
            isGrounded = true;
            gameObject.layer = LayerMask.NameToLayer("Obstacle");
        }
    }

    void OnCollisionExit2D (Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground") && isGrounded == true)
        {
            isGrounded = false;

            if (isInteracting == true)
            {
                gameObject.layer = LayerMask.NameToLayer("NoCollision");

                isInteracting = false;

                rb.linearVelocity = Vector2.zero;
                rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

                if (pushPullSound.isPlaying)
                {
                    pushPullSound.Stop();
                }

                GameObject player = GameObject.FindGameObjectWithTag("Player");
                if (player != null)
                {
                    PlayerController pc = player.GetComponent<PlayerController>();
                    if (pc != null)
                    {
                        pc.StartCoroutine(pc.FallingSequence());
                    }
                }
            }
        }
    }
}

