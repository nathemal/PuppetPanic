using UnityEngine;

public class InteractScript : MonoBehaviour
{
    public GameObject pressE;
    BoxCollider2D col;
    bool canMove = false;
    private void Start()
    {
        col = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && canMove) // TODO: This input needs to be changed to the input system to keep compatibility with controllers
        {
            col.enabled = true;
            pressE.SetActive(false);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {   
        if(collision.tag == "Player" && !canMove)
        {
            pressE.SetActive(true);
            canMove = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            pressE.SetActive(false);
        }
    }
}
