using UnityEngine;

public class ChangeAfterFall : MonoBehaviour
{
    public GameObject afterFall;

    private int defaultLayer;
    private int noCollisionLayer;
    private int lastLayer;

    void Start()
    {
        defaultLayer = LayerMask.NameToLayer("Default");
        noCollisionLayer = LayerMask.NameToLayer("NoCollision");
        lastLayer = gameObject.layer;
    }

    void Update()
    {
        int currentLayer = gameObject.layer;

        if (lastLayer == noCollisionLayer && currentLayer == defaultLayer)
        {
            Change();
        }

        lastLayer = currentLayer;
    }

    private void Change()
    {
        Instantiate(afterFall, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
