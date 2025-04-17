using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private bool IsAlive;

    public float cameraShakeAmount;
    public float cameraShakeTime;

    private void Start()
    {
        IsAlive = true;
    }

    private void Update()
    {
        if(MainManager.health == 0)
        {
            IsAlive = false;
        }
    }

    public void ReduceHealth()
    {
        MainManager.health--;
        Camera.main.GetComponent<CameraShake>().ShakeCamera(cameraShakeAmount, cameraShakeTime, true, true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            ReduceHealth();
        }
    }
}
