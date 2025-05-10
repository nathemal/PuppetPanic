using UnityEngine;

public class JumpThrough : MonoBehaviour
{
    private Rigidbody2D rb;
    private int playerLayer;
    private int platformLayer;
    public bool collisionDisable = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rb.linearVelocity.y > 0.01f)
        {
            if (collisionDisable == false)
            {
                gameObject.layer = LayerMask.NameToLayer("Jumping");
                collisionDisable = true;
            }
        }
        else if (rb.linearVelocity.y < 0.01f)
        {
            if (collisionDisable == true)
            {
                gameObject.layer = LayerMask.NameToLayer("Default");
                collisionDisable = false;
            }
        }
    }
}
