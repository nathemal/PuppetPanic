using Unity.VisualScripting;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject featherUI;
    public GameObject flowerUI;
    public GameObject furUI;
    public GameObject gemUI;
    public GameObject ringUI;

    public GameObject inventory;

    public GameObject rippedBook;

    private void Update()
    {
        if (MainManager.inventoryActive == true)
        {
            inventory.SetActive(true);
        }

        if (MainManager.ringCollected == true)
        {
            ringUI.SetActive(true);
        }

        if (MainManager.featherCollected == true)
        {
            featherUI.SetActive(true);
        }

        if(MainManager.flowerCollected == true)
        {
            flowerUI.SetActive(true);
        }

        if (MainManager.furCollected == true)
        {
            furUI.SetActive(true);
        }

        if (MainManager.gemCollected == true)
        {
            gemUI.SetActive(true);
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MagicBook" && Input.GetKey(KeyCode.E))
        {
            MainManager.inventoryActive = true;
            Instantiate(
            rippedBook,
            collision.transform.position,
            collision.transform.rotation);

            Destroy(collision.gameObject);
        }

        if (collision.gameObject.name.Equals("Ring") && Input.GetKey(KeyCode.E))
        {
            MainManager.ringCollected = true;
        }

        if (collision.gameObject.name.Equals("Feather") && Input.GetKey(KeyCode.E))
        {
            MainManager.featherCollected = true;
        }

        if (collision.gameObject.name.Equals("Flower") && Input.GetKey(KeyCode.E))
        {
            MainManager.flowerCollected = true;
        }

        if (collision.gameObject.name.Equals("Fur") && Input.GetKey(KeyCode.E))
        {
            MainManager.furCollected = true;
        }

        if (collision.gameObject.name.Equals("Gem") && Input.GetKey(KeyCode.E))
        {
            MainManager.gemCollected = true;
        }
    }

}
