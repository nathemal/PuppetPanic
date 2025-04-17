using Unity.VisualScripting;
using UnityEngine;

public class InteractWithObject : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0, 7, 0);

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Object" && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(collision.gameObject);
            MainManager.objectCounter++;
        }

        if(collision.gameObject.tag == "PushableObject" && Input.GetKeyDown(KeyCode.E))
        {
            gameObject.transform.position = player.position + offset;
        }
    }
}
