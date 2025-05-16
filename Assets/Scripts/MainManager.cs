using UnityEngine;

public class MainManager : MonoBehaviour
{
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

    public Timer timer;

    void Update()
    {
        ActivateCaughtScreen();
        ActivateWinScreen();

        if (Input.GetKeyDown(KeyCode.Space)) // This is for debugging purposes
        {
            PuppetEscapes();
        }
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

            timer.stopTimer();
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

    public void PickedUpObject()
    {
        objectCounter++;
    }
}
