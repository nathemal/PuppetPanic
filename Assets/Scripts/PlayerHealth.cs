using UnityEngine;
using UnityEngine.Rendering;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    static public bool isAlive = true;

    public float cameraShakeAmount;
    public float cameraShakeTime;

    public AudioSource takeDamageSound;
    public AudioSource lowHealthSound;
    public Volume lowHealthVolume;
    public Volume takeDamageVolume;
    public float damagefdbktime = 0.2f;

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
        
        Camera.main.GetComponent<CameraShake>().ShakeCamera(cameraShakeAmount, cameraShakeTime, true, true);
        
        takeDamageSound.Play();

        takeDamageVolume.weight = 1;
        
        StartCoroutine(Waiter());
    }

    IEnumerator Waiter()
    {
        yield return new WaitForSeconds(damagefdbktime);

        takeDamageVolume.weight = 0;
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
        if (MainManager.currentHealth <= 2)
        {
            healthIsLow = true;
            float weight = 1;
            weight += 0.5f * Mathf.PingPong(Time.time, 0.5f * (1.2f - weight));
            lowHealthVolume.weight = Mathf.SmoothStep(0, 1, weight);
        }

        if (healthIsLow && !lowHealthSound.isPlaying)
        {
                lowHealthSound.Play();
        }
    }

}
