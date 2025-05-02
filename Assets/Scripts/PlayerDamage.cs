using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    float airTime = 0;
    public float startTakingDamTime = 1;
    private void Update()
    {
        FallDamage();
    }

    public void FallDamage()
    {
        if(PlayerController.isGrounded == false)
        {
            airTime = Time.deltaTime;
            Debug.Log(airTime.ToString());
        }
        else if(PlayerController.isGrounded == true)
        {
            airTime = 0;
            Debug.Log(airTime.ToString());
        }
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground" && airTime > startTakingDamTime)
        {
            MainManager.health -= (int)airTime;
            Debug.Log("IS TAKING DAMAGE");
        }
    }
}
