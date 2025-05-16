using UnityEngine;
using UnityEngine.UIElements;

public class Timer : MonoBehaviour
{
    public MainManager mainManager;
    public UIDocument uiDocument_WinScreen;
    
    public bool timerIsRunning = false; // TODO: Make this variable private when done implementing everything

    private Label timeLabel_WinScreen;

    private void Update()
    {
        if (timerIsRunning)
        {
            if (MainManager.remainingTime >= 0)
            {
                MainManager.remainingTime -= Time.deltaTime;
                
                Debug.Log("Time remaining: " + MainManager.remainingTime);
            }
            else
            {
                Debug.Log("Time has run out!");
                MainManager.remainingTime = 0;
                
                mainManager.PuppetIsCaught();
                stopTimer();
            }
        }
    }

    public void startTimer()
    {
        timerIsRunning = true;
    }

    public void stopTimer() 
    {
        timerIsRunning = false;

        displayFinalTime();
    }

    private void displayFinalTime()
    {
        VisualElement root = uiDocument_WinScreen.rootVisualElement;

        timeLabel_WinScreen = root.Q<Label>("Time");

        timeLabel_WinScreen.text = "You had " + calcTime() + " left";
    }

    private string calcTime()
    {
        int minutes = (int)MainManager.remainingTime / 60;
        int seconds = (int)MainManager.remainingTime % 60;

        return string.Format(minutes + "min:" + seconds + "sec");
    }
}
