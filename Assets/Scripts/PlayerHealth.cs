using UnityEngine;
using Unity.Cinemachine;

public class PlayerHealth : MonoBehaviour
{
    public CinemachineImpulseSource DamageInpuse;
    public CinemachineImpulseSource LowHealthImpulse;
    private bool IsAlive;

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
        DamageInpuse.GenerateImpulse();
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
        if (MainManager.health < 5)
        {
            LowHealthImpulse.GenerateImpulse();
        }
    }
}
