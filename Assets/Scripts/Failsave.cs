using UnityEngine;

public class Failsave : MonoBehaviour
{
    public GameObject shelf;
    public static bool triggered = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            shelf.SetActive(false);
            triggered = true;
            gameObject.SetActive(false);
        }
    }
}
