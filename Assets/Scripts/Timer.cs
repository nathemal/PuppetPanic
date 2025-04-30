using UnityEngine;
using UnityEngine.UIElements;

public class Timer : MonoBehaviour
{
    public Manager mainManager; // TODO: Remember to rename "Manager" here once the branches has been merged
    public UIDocument uiDocument_WinScreen;
    
    public bool timerIsRunning = false; // TODO: Make this variable private when done implementing everything

    private Label timeLabel_WinScreen;

    private void Update()
    {
        if (timerIsRunning)
        {
            if (Manager.remainingTime >= 0)
            {
                Manager.remainingTime -= Time.deltaTime;
                
                Debug.Log("Time remaining: " + Manager.remainingTime);
            }
            else
            {
                Debug.Log("Time has run out!");
                Manager.remainingTime = 0;
                
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
        int minutes = (int)Manager.remainingTime / 60;
        int seconds = (int)Manager.remainingTime % 60;

        return string.Format(minutes + "min:" + seconds + "sec");
    }
}
