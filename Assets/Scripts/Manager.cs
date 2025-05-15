using UnityEngine;

public class Manager : MonoBehaviour
{
    // This script should be merged into the MainManager.cs script when they have both been merged into the same branch

    public const float maxHealth = 10;
    public static float currentHealth = 10;
    public static int objectCounter = 0;
    public static float remainingTime = 100; // TODO: Change this variable to the desire timer lenght


    //
    //
    // Everything bellow this comment should maybe be put in it's own script but this works for now 
    //
    //

    public bool reduceHealth = false; // THIS IS PURELY FOR DEBUGGING - DO NOT USE FOR ANYTHING ELSE

    private bool isCaught = false;
    private bool wonGame = false;
    
    public GameObject CaughtScreen;
    public GameObject WinScreen;

    public HealthBarUI healthBarUI; 

    public Timer timer;

    void Update()
    {
       ActivateCaughtScreen();
       ActivateWinScreen();

        if (Input.GetKeyDown(KeyCode.Space)) // This is for debugging purposes
        {
            PuppetEscapes();
        }

        if (reduceHealth) // THIS IS PURELY FOR DEBUGGING - DO NOT USE FOR ANYTHING ELSE
        {
            currentHealth--;
            healthBarUI.SetHealth(currentHealth);
            reduceHealth = false;
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
            timer.displayFinalTime();
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
