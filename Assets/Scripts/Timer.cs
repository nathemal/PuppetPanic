using UnityEngine;
using UnityEngine.UIElements;

public class Timer : MonoBehaviour
{
    public Manager mainManager; // TODO: Remember to rename "Manager" here once the branches has been merged
    public UIDocument uiDocument_WinScreen;
    public UIDocument uiDocument_UI;
    
    public bool timerIsRunning = false; // TODO: Make this variable private when done implementing everything

    private Label timerLabel_WinScreen;
    private Label timerLabel_UI;

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

        displayTimerUI();
    }

    public void startTimer()
    {
        timerIsRunning = true;
    }

    public void stopTimer() 
    {
        timerIsRunning = false;
    }

    public void displayFinalTime()
    {
        VisualElement root = uiDocument_WinScreen.rootVisualElement;

        timerLabel_WinScreen = root.Q<Label>("Time");

        timerLabel_WinScreen.text = "You had " + formatTime() + " left";
    }

    private void displayTimerUI()
    {
        VisualElement root = uiDocument_UI.rootVisualElement;

        timerLabel_UI = root.Q<Label>("Timer");

        timerLabel_UI.text = formatTime();
    }

    private string formatTime()
    {
        string time = string.Format((int)Manager.remainingTime + "s");

        return time;
    }
}
