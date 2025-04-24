using UnityEngine;

public class Manager : MonoBehaviour
{
    // This script should be merged into the MainManager.cs script when they have both been merged into the same branch

    public static int health = 10;
    public static int objectCounter = 0;
    public static float remainingTime = 10; // TODO: Change this variable to the desire timer lenght
    

    //
    //
    // Everything bellow this comment should maybe be put in it's own script but this works for now 
    //
    //


    private bool isCaught = false;
    private bool wonGame = false;
    
    public GameObject CaughtScreen;
    public GameObject WinScreen;

    void Update()
    {
       ActivateCaughtScreen();
       ActivateWinScreen();
    }

    private void ActivateCaughtScreen()
    {
        if (isCaught)
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

    public void PuppetIsCaught()
    {
        isCaught = true;
    }

    public void PuppetEscapes()
    {
        wonGame = true;
    }
}
