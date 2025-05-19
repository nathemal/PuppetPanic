using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SceneTransitionScript : MonoBehaviour
{
    public bool inRange = false;

    InputAction interactAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactAction = InputSystem.actions.FindAction("Interact");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "Door" && inRange == true && interactAction.IsPressed())
        {
            SceneManager.LoadScene("Room 2");
        }
        else if (gameObject.tag == "Cannon" && inRange == true && interactAction.IsPressed())
        {
            SceneManager.LoadScene("Room 3");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = false;
        }
    }
}
