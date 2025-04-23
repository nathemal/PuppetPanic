using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private bool IsAlive = true;

    public AudioSource TakeDamageSound;
    public AudioSource LowHealthSound;

    bool HealthIsLow;

    private void Update()
    {
        if(MainManager.health == 0)
        {
            IsAlive = false;
        }

        LowHealth();
    }

    public void ReduceHealth()
    {   
        MainManager.health--;
        TakeDamageSound.Play();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            ReduceHealth();
        }
    }

    public void LowHealth()
    {
        if (MainManager.health <= 5)
        {
            HealthIsLow = true;
        }

        if (HealthIsLow)
        {
            if (!LowHealthSound.isPlaying)
            {
                LowHealthSound.Play();
            }
        }
        else
        {
            if (LowHealthSound.isPlaying)
            {
                LowHealthSound.Stop();
            }
        }
    }
}
