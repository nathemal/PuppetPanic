using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
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
    }
}
