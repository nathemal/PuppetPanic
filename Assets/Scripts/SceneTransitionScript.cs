using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SceneTransitionScript : MonoBehaviour
{
    public static SceneTransitionScript Instance;

    public bool inRange = false;

    public bool moveToRoom2 = false;
    public bool moveToRoom3 = false;
    public bool canWin = false;

    InputAction interactAction;

    public GameObject winScreen;
    public GameObject caughtScreen;
    public AudioSource backgroundMusic;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactAction = InputSystem.actions.FindAction("Interact");

    }

    // Update is called once per frame
    void Update()
    {
        if (MainManager.objectCounter == 1)
        {
            moveToRoom2 = true;
        }
        if (MainManager.objectCounter == 2)
        {
            moveToRoom3 = true;
        }

        if (MainManager.objectCounter == 4)
        {
            canWin = true;
        }

        if (gameObject.tag == "Door" && inRange == true && interactAction.IsPressed() && moveToRoom2 == true)
        {
            SceneManager.LoadScene("Room 2");
        }
        else if (gameObject.tag == "Cannon" && inRange == true && interactAction.IsPressed() && moveToRoom3 == true)
        {
            SceneManager.LoadScene("Room 3");
        }
        else if (gameObject.tag == "Slide" && inRange == true && interactAction.IsPressed() && canWin == true)
        {
            winScreen.SetActive(true);
            backgroundMusic.Stop();
        }
        else if (gameObject.tag == "Void" && inRange == true)
        {
            caughtScreen.SetActive(true);
            backgroundMusic.Stop();
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
