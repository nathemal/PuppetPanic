using UnityEngine;

public class DrawerObject : MonoBehaviour
{
    public GameObject Open;

    private bool inRange = false;

    void Start()
    {
        if (Open != null)
        {
            Open.SetActive(false);
        }
    }

    void Update()
    {
        if (inRange == true && Input.GetKeyDown(KeyCode.E) && PushPullObject.instance.isInteracting == false)
        {
            Open.SetActive(!Open.activeSelf);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = false;
        }
    }
}
