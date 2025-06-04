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

    private void Update()
    {
        if(MainManager.ringCollected)
        {
            ringUI.SetActive(true);
        }

        if (MainManager.featherCollected)
        {
            featherUI.SetActive(true);
        }

        if(MainManager.flowerCollected)
        {
            flowerUI.SetActive(true);
        }

        if (MainManager.furCollected)
        {
            furUI.SetActive(true);
        }

        if (MainManager.gemCollected)
        {
            gemUI.SetActive(true);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MagicBook" && Input.GetKey(KeyCode.E))
        {
            inventory.SetActive(true);
        }

        if (collision.gameObject.name.Equals("Ring") && Input.GetKey(KeyCode.E))
        {
            MainManager.ringCollected = true;
        }

        if (collision.gameObject.name.Equals("Object") && Input.GetKey(KeyCode.E))
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
