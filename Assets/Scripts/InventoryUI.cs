using Unity.VisualScripting;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public static GameObject featherUI;
    public static GameObject flowerUI;
    public static GameObject furUI;
    public static GameObject gemUI;
    public static GameObject ringUI;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.name.Equals("Ring") && Input.GetKey(KeyCode.E))
        {
            Debug.Log("ISCOLLECTED");
            ringUI.SetActive(true);
        }

        if (collision.gameObject.name.Equals("Object") && Input.GetKey(KeyCode.E))
        {
            Debug.Log("ISCOLLECTED");
            featherUI.SetActive(true);
        }

        if (collision.gameObject.name.Equals("Flower") && Input.GetKey(KeyCode.E))
        {
            Debug.Log("ISCOLLECTED");
            flowerUI.SetActive(true);
        }

        if (collision.gameObject.name.Equals("Fur") && Input.GetKey(KeyCode.E))
        {
            Debug.Log("ISCOLLECTED");
            furUI.SetActive(true);
        }

        if (collision.gameObject.name.Equals("Gem") && Input.GetKey(KeyCode.E))
        {
            Debug.Log("ISCOLLECTED");
            gemUI.SetActive(true);
        }
    }
}
