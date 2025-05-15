using UnityEngine;
using UnityEngine.InputSystem;

public class InteractScript : MonoBehaviour
{
    public GameObject pressE;
    BoxCollider2D col;
    bool canMove = false;

    InputAction interactAction;
    
    private void Start()
    {
        col = GetComponent<BoxCollider2D>();
        interactAction = InputSystem.actions.FindAction("Interact");
    }

    private void Update()
    {
        if(interactAction.IsPressed() && canMove)
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
