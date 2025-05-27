using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    static public bool isAlive = true;

    public AudioSource takeDamageSound;
    public AudioSource lowHealthSound;

    bool healthIsLow;

    private void Update()
    {
        if(MainManager.currentHealth <= 0)
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            ReduceHealth();
            Debug.Log(MainManager.currentHealth.ToString());
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
    }

}
