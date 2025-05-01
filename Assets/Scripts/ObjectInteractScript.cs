using UnityEngine;

public class ObjectInteractScript : MonoBehaviour
{
    public GameObject pressE;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            pressE.SetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            pressE.SetActive(false);
        }
    }
}
