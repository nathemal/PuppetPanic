using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

// This Script handles transitioning between the different Scenes
public class SceneTransitionScript : MonoBehaviour
{
    public bool inRange = false;

    InputAction interactAction;

    public Image fadeImage;
    public float fadeDuration = 1f;
    public AudioSource CannonShot;
    public GameObject UI;

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
                if (WinCondition.canEnterRoom3 && interactAction.WasPressedThisFrame())
                {
                    StartCoroutine(FadeAndLoadScene("Room 3"));
                }
                break;

            case "Slide":

                if (WinCondition.canLeaveRoom3 && interactAction.IsPressed())
                {
                    SceneManager.LoadScene("Room 2");
                }
                break;

            case "Exit":

                if (WinCondition.canWin)
                {
                    SceneManager.LoadScene("Room 4");
                }
                break;
        }
    }

    IEnumerator FadeAndLoadScene(string sceneName)
    {
        UI.SetActive(false);
        float t = 0f;
        Color color = fadeImage.color;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            color.a = Mathf.Clamp01(t / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }
        CannonShot.Play();
        yield return new WaitForSeconds(CannonShot.clip.length);
        SceneManager.LoadScene(sceneName);
        UI.SetActive(true);
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
