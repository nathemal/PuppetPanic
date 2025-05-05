using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public Rigidbody2D rb;
    float y;
    public float maxYVelocity = -20;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        y = rb.linearVelocity.y;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground" && y <= maxYVelocity)
        {
                MainManager.health -= 1;
                Debug.Log("HEALTH");
                Debug.Log(MainManager.health.ToString());
            }
        }
}
