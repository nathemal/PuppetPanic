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
    public AudioSource Sliding;
    public AudioSource CannonShot;
    public AudioSource EnterTent;
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
                    StartCoroutine(FadeAndRoom1To2());
                }
                break;

            case "Cannon":
                if (WinCondition.canEnterRoom3 && interactAction.WasPressedThisFrame())
                {
                    StartCoroutine(FadeAndRoom2To3());
                }
                break;

            case "Slide":

                if (WinCondition.canLeaveRoom3 && interactAction.IsPressed())
                {
                    StartCoroutine(FadeAndRoom3To4());
                }
                break;
        }
    }

    IEnumerator FadeAndRoom1To2()
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
        BackgroundMusicHandler.Instance.GetComponent<AudioSource>().Pause();
        EnterTent.Play();
        yield return new WaitForSeconds(EnterTent.clip.length);
        SceneManager.LoadScene("Room 2");
        UI.SetActive(true);
        BackgroundMusicHandler.Instance.GetComponent<AudioSource>().Play();
    }

    IEnumerator FadeAndRoom2To3()
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
        BackgroundMusicHandler.Instance.GetComponent<AudioSource>().Pause();
        CannonShot.Play();
        yield return new WaitForSeconds(CannonShot.clip.length);
        SceneManager.LoadScene("Room 3");
        UI.SetActive(true);
        BackgroundMusicHandler.Instance.GetComponent<AudioSource>().Play();
    }

    IEnumerator FadeAndRoom3To4()
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
        BackgroundMusicHandler.Instance.GetComponent<AudioSource>().Stop();
        Sliding.Play();
        yield return new WaitForSeconds(Sliding.clip.length);
        //SceneManager.LoadScene("Room 4");
        Manager.PuppetEscapes();
        //UI.SetActive(true);
        //BackgroundMusicHandler.Instance.GetComponent<AudioSource>().Play();
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
