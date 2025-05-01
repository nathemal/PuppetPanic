using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    public int objWinAmount = 1;

    private void Update()
    {
        CheckForObjects();
    }

    public void CheckForObjects()
    {
        if(MainManager.objectCounter == objWinAmount)
        {
            SceneManager.LoadScene("WinLoseScreensTest");
        }
    }
}
