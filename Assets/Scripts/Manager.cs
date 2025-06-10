using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    // This script should maybe be merged into the MainManager.cs script when they have both been merged into the same branch


    public bool reduceHealth = false; // THIS IS PURELY FOR DEBUGGING - DO NOT USE FOR ANYTHING ELSE

    public static bool isCaught = false;
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

    public static void ResetGame()
    {

        Time.timeScale = 1f;
        isCaught = false;
        wonGame = false;
        Timer.timerIsRunning = false;
        MainManager.objectCounter = 0;
        MainManager.currentHealth = 5;
        //healthBarUI.UpdateHealthBar();
        PlayerHealth.isAlive = true;
        Failsave.triggered = false;

        MainManager.inventoryActive = false;
        MainManager.ringCollected = false;
        MainManager.featherCollected = false;
        MainManager.flowerCollected = false;
        MainManager.gemCollected = false;
        MainManager.furCollected = false;

        MainManager.remainingTime = MainManager.maxTime;
    }

    private void ActivateCaughtScreen()
    {
        if (isCaught)
        {
            BackgroundMusicHandler.Instance.GetComponent<AudioSource>().Stop();
            CaughtScreen.SetActive(true);
            userInterface.SetActive(false); //for showcasing purposes

            Time.timeScale = 0.001f;
        }
    }

    private void ActivateWinScreen()
    {
        if (wonGame) 
        {
            BackgroundMusicHandler.Instance.GetComponent<AudioSource>().Stop();
            WinScreen.SetActive(true);
            userInterface.SetActive(false); //for showcasing purposes
            timer.stopTimer();
            timer.displayFinalTime();

            Time.timeScale = 0.001f;
        }
    }

    public static void PuppetIsCaught()
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
