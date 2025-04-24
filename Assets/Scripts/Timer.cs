using UnityEngine;

public class Timer : MonoBehaviour
{
    public Manager mainManager;
    
    public bool timerIsRunning = false; // TODO: Make this variable private when done implementing everything

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
    }
}
