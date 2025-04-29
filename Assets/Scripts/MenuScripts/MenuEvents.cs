using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuEvents : MonoBehaviour
{
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void ButtonClickedEvent()
    {
        // TODO: This function is run anytime a button is clicked, if we want some sound or something else to happen every time it happens do that here

        Debug.Log("A button was clicked");
        return;
    }
}
