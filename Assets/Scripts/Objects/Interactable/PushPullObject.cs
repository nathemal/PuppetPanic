using UnityEngine;

public class PushPullObject : MonoBehaviour
{
    public static PushPullObject instance;

    public float Speed = 5f;

    private RigidbodyType2D defaultBodyType;
    private Rigidbody2D rb;
    public bool isInteracting = false;
    private Transform player;
    private bool inRange = false;
    private Vector2 lastPlayerPos;
    private RigidbodyConstraints2D originalConstraints;
    private bool isGrounded = true;

    private void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        defaultBodyType = rb.bodyType;
        originalConstraints = rb.constraints;
        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange == true && Input.GetKeyDown(KeyCode.E))
        {
            isInteracting = !isInteracting;

            if (isInteracting)
            {
                lastPlayerPos = player.position;
                rb.constraints = originalConstraints;
                rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            }
            else
            {
                rb.linearVelocity = Vector2.zero;
                rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
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
            }

            lastPlayerPos = currentPlayerPos;
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
                isInteracting = false;
                rb.linearVelocity = Vector2.zero;
                rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            }

            gameObject.layer = LayerMask.NameToLayer("NoCollision");
        }
    }
}

