using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private bool isAlive = true;

    public AudioSource takeDamageSound;
    public AudioSource lowHealthSound;

    bool healthIsLow;

    private void Update()
    {
        if(MainManager.currentHealth == 0)
        {
            isAlive = false;
        }

        LowHealth();
    }

    public void ReduceHealth()
    {   
        MainManager.currentHealth--;
        takeDamageSound.Play();
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
        if (MainManager.currentHealth <= 5)
        {
            healthIsLow = true;
        }

        if (healthIsLow && !lowHealthSound.isPlaying)
        {
                lowHealthSound.Play();
        }
        else if(lowHealthSound.isPlaying)
        {
                lowHealthSound.Stop();
        }
    }
}
