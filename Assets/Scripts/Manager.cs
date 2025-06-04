using UnityEngine;

public class Manager : MonoBehaviour
{
    // This script should be merged into the MainManager.cs script when they have both been merged into the same branch


    public static float remainingTime = 10; // TODO: Change this variable to the desire timer lenght


    //
    //
    // Everything bellow this comment should maybe be put in it's own script but this works for now 
    //
    //

    public bool reduceHealth = false; // THIS IS PURELY FOR DEBUGGING - DO NOT USE FOR ANYTHING ELSE

    private bool isCaught = false;
    public static bool wonGame = false;

    public GameObject userInterface;

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
            MainManager.currentHealth--;
            healthBarUI.UpdateHealthBar();
            reduceHealth = false;
        }

        if (PlayerHealth.isAlive == false)
        {
            PuppetIsCaught();
        }
    }

    private void ActivateCaughtScreen()
    {
        if (isCaught)
        {
            BackgroundMusicHandler.Instance.GetComponent<AudioSource>().Stop();
            CaughtScreen.SetActive(true);
            userInterface.SetActive(false); //for showcasing purposes

            Time.timeScale = 0;
        }
    }

    private void ActivateWinScreen()
    {
        if (wonGame) 
        {
            //BackgroundMusicHandler.Instance.GetComponent<AudioSource>().Stop();
            WinScreen.SetActive(true);
            userInterface.SetActive(false); //for showcasing purposes
            timer.stopTimer();
            timer.displayFinalTime();

            Time.timeScale = 0;
        }
    }

    public void PuppetIsCaught()
    {
        isCaught = true;
    }

    public static void PuppetEscapes()
    {
        wonGame = true;
    }

    public void PickedUpObject()
    {
        MainManager.objectCounter++;
    }
}
