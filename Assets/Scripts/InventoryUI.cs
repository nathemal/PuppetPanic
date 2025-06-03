using Unity.VisualScripting;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject featherUI;
    public GameObject flowerUI;
    public GameObject furUI;
    public GameObject gemUI;
    public GameObject ringUI;

    public GameObject feather;
    public GameObject flower;
    public GameObject fur;
    public GameObject gem;
    public GameObject ring;


    private void Update()
    {
        IsCollected();
    }

    public void IsCollected()
    {
        if(ring.IsDestroyed())
        {
            ringUI.SetActive(true);
        }
    }
}
