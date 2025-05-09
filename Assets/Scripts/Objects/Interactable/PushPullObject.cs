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
    }

    void Update()
    {
        if (inRange == true && interactAction.IsPressed())
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
    }

    void FixedUpdate()
    {
        if (isInteracting == true)
        {
            Vector2 currentPlayerPos = player.position;
            Vector2 playerMovement = currentPlayerPos - lastPlayerPos;

            if (playerMovement.sqrMagnitude > 0.0001f)
            {
                rb.MovePosition(rb.position + playerMovement);

                if (!pushPullSound.isPlaying)
                {
                    pushPullSound.Play();
                }
            }
            else
            {
                if (pushPullSound.isPlaying)
                {
                    pushPullSound.Stop();
                }
            }

            lastPlayerPos = currentPlayerPos;
        }

        if (isInteracting)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
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
            gameObject.layer = LayerMask.NameToLayer("Default");
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
            }
        }
    }
}

