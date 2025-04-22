using UnityEngine;
using Unity.Cinemachine;

public class PlayerHealth : MonoBehaviour
{
    public CinemachineImpulseSource DamageInpuse;
    public CinemachineImpulseSource LowHealthImpulse;
    private bool IsAlive;

    public AudioSource TakeDamageSound;
    public AudioSource LowHealthSound;

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
            if (!TakeDamageSound.isPlaying)
            {
                LowHealthSound.Play();
            }
        }
    }
}
