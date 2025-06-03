using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    public int objWinAmount = 5;
    public static bool canEnterRoom2 = false;
    public static bool canEnterRoom3 = false;
    public static bool canLeaveRoom3 = false;
    public static bool canWin = false;
    public Manager manager;
    public GameObject TentExit;

    private void Start()
    {
        TentExit.SetActive(false);
    }
    private void Update()
    {
        CheckForObjects();

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
        }

        if (canWin)
        {
            TentExit.SetActive(true);
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
