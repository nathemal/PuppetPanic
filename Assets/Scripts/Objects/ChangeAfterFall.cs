using NUnit.Framework.Api;
using UnityEditor;
using UnityEngine;

public class ChangeAfterFall : MonoBehaviour
{
    public GameObject afterFall;

    private int defaultLayer;
    private int noCollisionLayer;
    private int lastLayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        defaultLayer = LayerMask.NameToLayer("Default");
        noCollisionLayer = LayerMask.NameToLayer("NoCollision");
        lastLayer = gameObject.layer;
    }

    // Update is called once per frame
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
