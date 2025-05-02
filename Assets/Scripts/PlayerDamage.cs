using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    float airTime = 0;
    public float startTakingDamTime = 3f;
    private void Update()
    {
        FallDamage();
    }

    public void FallDamage()
    {
        if(PlayerController.isGrounded == false)
        {
            airTime += Time.time / 100;
            Debug.Log(airTime.ToString());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground" && airTime > startTakingDamTime)
        {
            MainManager.health -= ((int)airTime ^ 2 / 5);
            Debug.Log("HEALTH");
            Debug.Log(MainManager.health.ToString());
            airTime = 0;
        }
    }
}
