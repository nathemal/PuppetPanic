using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class InteractWithObject : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(1, 0, 0);
    public GameObject Object;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Object" && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(collision.gameObject);
            MainManager.objectCounter++;
        }

        if(collision.gameObject.tag == "PushableObject" && Input.GetKey(KeyCode.E))
        {
            //gameObject.transform.position = player.position + offset;

            Object.transform.position = player.position + offset;
        }
    }
}
