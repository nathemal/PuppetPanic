using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.Rendering;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    private bool isAlive = true;

    public float cameraShakeAmount;
    public float cameraShakeTime;

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

        Camera.main.GetComponent<CameraShake>().ShakeCamera(cameraShakeAmount, cameraShakeTime, true, true);
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
        if (MainManager.health <= 5)
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
