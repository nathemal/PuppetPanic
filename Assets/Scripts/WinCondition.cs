using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    public static int objWinAmount = 4;
    public GameObject WinScreen;

    private void Start()
    {
        WinScreen.SetActive(false);

        string activeSceneName = SceneManager.GetActiveScene().name;

        if (activeSceneName == "Room 3")
        {
            MainManager.objectCounter = 2;
        }

        if (activeSceneName == "Room 3" && MainManager.objectCounter == 4)
        {
            SceneTransitionScript.Instance.canWin = true;
        }
    }

    private void Update()
    {
        CheckForObjects();

        Debug.Log(MainManager.objectCounter);
    }

    public void CheckForObjects()
    {
        if(MainManager.objectCounter == objWinAmount)
        {
            
            Timer.instance.stopTimer();
        }
    }
}
