using TMPro;
using UnityEngine;

public class InteractScript : MonoBehaviour
{
    public GameObject pressE;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Object")
        {
            pressE.SetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Object")
        {
            pressE.SetActive(false);
        }
    }
}
