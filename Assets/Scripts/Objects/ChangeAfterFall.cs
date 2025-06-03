using UnityEngine;

public class ChangeAfterFall : MonoBehaviour
{
    public static ChangeAfterFall Instance;

    public GameObject afterFall;
    public AudioSource landingSound;

    public float yCorrection = 0f; //change this to above 0 if the object spawns in the ground, should be kept public as the value needed can differ by object.

    private int defaultLayer;
    private int noCollisionLayer;
    private int lastLayer;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        defaultLayer = LayerMask.NameToLayer("Obstacle");
        noCollisionLayer = LayerMask.NameToLayer("NoCollision");
        lastLayer = gameObject.layer;
    }

    void Update()
    {
        int currentLayer = gameObject.layer;

        if (lastLayer == noCollisionLayer && currentLayer == defaultLayer)
        {
            landingSound.Play();
            Change();
        }

        lastLayer = currentLayer;
    }

    public void FailsafeFall()
    {
        if (landingSound != null)
        {
            landingSound.Play();
        }

        Change();
    }

    public void Change()
    {
        Vector3 positionCorrection = transform.position + new Vector3(0, yCorrection, 0);
        Instantiate(afterFall, positionCorrection, transform.rotation);
        Destroy(gameObject);
    }
}
