using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    Rigidbody2D rb;
    float y;
    public float maxYVelocity = -20;
    public PlayerHealth playerHealth;
    

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
        if (collision.gameObject.tag == "Ground" && y <= maxYVelocity)
        {
            playerHealth.ReduceHealth();
            Debug.Log("HEALTH");
            Debug.Log(MainManager.health.ToString());

        }
    }
}
