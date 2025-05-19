using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private bool isAlive = true;

    public AudioSource takeDamageSound;
    public AudioSource lowHealthSound;

    bool healthIsLow;

    private void Update()
    {
        if(MainManager.health == 0)
        {
            isAlive = false;
        }

        LowHealth();
    }

    public void ReduceHealth()
    {   
        MainManager.health--;
        takeDamageSound.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            ReduceHealth();
            Debug.Log(MainManager.health.ToString());
        }
    }

    public void LowHealth()
    {
        if (MainManager.health <= 5)
        {
            healthIsLow = true;
        }

        if (healthIsLow && !lowHealthSound.isPlaying)
        {
                lowHealthSound.Play();
        }
    }
}
