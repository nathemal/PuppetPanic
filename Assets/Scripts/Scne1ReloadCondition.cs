using Unity.VisualScripting;
using UnityEngine;

public class Scne1ReloadCondition : MonoBehaviour
{
    public GameObject book;
    public GameObject ring;
    public GameObject player;
    private void Start()
    {
        if(MainManager.objectCounter == 5)
        {
            RearangeScene();
        }
    }

    public void RearangeScene()
    {
        book.SetActive(false);
        ring.SetActive(false);

        player.transform.position = new Vector3(90, -29, 0);
    }
}
