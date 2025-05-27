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

        string sceneName = SceneManager.GetActiveScene().name; //TODO: Remove once objectCounter variable is carried over between scenes.

        if (sceneName == "Room 2") //TODO: Remove once objectCounter variable is carried over between scenes.
        {
            MainManager.objectCounter = 1;
        }

        if (sceneName == "Room 3") //TODO: Remove once objectCounter variable is carried over between scenes.
        {
            MainManager.objectCounter = 3;
        }
    }

    void Update()
    {
        if (!inRange) return;

        switch (gameObject.tag)
        {
            case "Opening":

                if (WinCondition.canEnterRoom2)
                {
                    SceneManager.LoadScene("Room 2");
                }
                break;

            case "Cannon":
                if (WinCondition.canEnterRoom3 && interactAction.IsPressed())
                {
                    SceneManager.LoadScene("Room 3");
                }
                break;

            case "Slide":

                if (WinCondition.canLeaveRoom3 && interactAction.IsPressed())
                {
                    //SceneManager.LoadScene("Room 2"); //Deactivated for showcase
                    Manager.PuppetEscapes();
                }
                break;
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
