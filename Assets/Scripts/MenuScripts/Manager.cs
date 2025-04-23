using UnityEngine;

public class Manager : MonoBehaviour
{
    // This script should be merged into the MainManager.cs script when they have both been merged into the same branch

    public static int health = 10;
    public static int objectCounter = 0;
    public static int timer = 100;
    
    public static bool wereCaught = false;
    public static bool wonGame = false;

    public GameObject CaughtScreen;
    public GameObject WinScreen;

    void Update()
    {
       ActivateCaughtScreen();
       ActivateWinScreen();
    }

    private void ActivateCaughtScreen()
    {
        if (timer <= 0 || wereCaught)
        {
            CaughtScreen.SetActive(true);
        }
    }

    private void ActivateWinScreen()
    {
        if (wonGame) 
        {
            WinScreen.SetActive(true);
        }
    }
}
