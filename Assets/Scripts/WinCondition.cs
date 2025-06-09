using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    public const int objWinAmount = 5;
    public static bool EnteredRoom3 = false; // This variable is never used?
    public static bool canEnterRoom2 = false;
    public static bool canEnterRoom3 = false;
    public static bool canLeaveRoom3 = false;
    public static bool canWin = false;

    private void Update()
    {
        CheckForObjects();

        if (MainManager.objectCounter == 0)
        {
            canEnterRoom2 = false;
            canEnterRoom3 = false;
            canLeaveRoom3 = false;
            canWin = false;
        }

        if (MainManager.objectCounter == 1)
        {
            canEnterRoom2 = true;
        }
        
        if (MainManager.objectCounter == 3)
        {
            canEnterRoom3 = true;
        }
        
        if (MainManager.objectCounter == 5)
        {
            canLeaveRoom3 = true;
            canWin = true;
        }
    }

    public void CheckForObjects()
    {
        if(MainManager.objectCounter == objWinAmount)
        {
            canWin = true;
        }
    }
}
