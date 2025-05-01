using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public int objWinAmount = 1;
    bool hasWon = false;

    private void Update()
    {
        CheckForObjects();
    }

    public void CheckForObjects()
    {
        if(MainManager.objectCounter == objWinAmount)
        {
            hasWon = true;
        }
    }
}
