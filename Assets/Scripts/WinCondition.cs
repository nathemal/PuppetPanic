using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    // This script could maybe be merged into the MainManger script

    public MainManager mainManager;
    
    public int objWinAmount = 1;

    private void Update()
    {
        CheckForObjects();
    }

    public void CheckForObjects()
    {
        if(MainManager.objectCounter == objWinAmount)
        {
            mainManager.PuppetEscapes();
        }
    }
}
