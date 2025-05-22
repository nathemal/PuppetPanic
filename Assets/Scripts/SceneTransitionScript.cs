using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

// This Script handles transitioning between the different Scenes
public class SceneTransitionScript : MonoBehaviour
{
    public bool inRange = false;

    InputAction interactAction;

    void Start()
    {
        interactAction = InputSystem.actions.FindAction("Interact");

        string sceneName = SceneManager.GetActiveScene().name; //Remove once objectCounter variable is carried over between scenes.

        if (sceneName == "Room 2") //Remove once objectCounter variable is carried over between scenes.
        {
            MainManager.objectCounter = 1;
        }

        if (sceneName == "Room 3") //Remove once objectCounter variable is carried over between scenes.
        {
            MainManager.objectCounter = 3;
        }
    }

    void Update()
    {
        if (gameObject.tag == "Opening" && inRange == true && WinCondition.canEnterRoom2 == true)
        {
            SceneManager.LoadScene("Room 2");
        }
        else if (gameObject.tag == "Cannon" && inRange == true && WinCondition.canEnterRoom3 == true && interactAction.IsPressed())
        {
            SceneManager.LoadScene("Room 3");
        }
        else if (gameObject.tag == "Slide" && inRange == true && WinCondition.canLeaveRoom3 == true && interactAction.IsPressed())
        {
            SceneManager.LoadScene("Room 2");
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
