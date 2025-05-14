using UnityEngine;

public class KnockBackScript : MonoBehaviour
{
    public float knockBackForce;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Vector2 direction = collision.transform.position - transform.position;
            direction *= knockBackForce;

            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(direction);
        }
    }
}