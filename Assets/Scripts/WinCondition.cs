using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    public int objWinAmount = 1;
    public Manager manager;

    private void Update()
    {
        CheckForObjects();
    }

    public void CheckForObjects()
    {
        if(MainManager.objectCounter == objWinAmount)
        {
            manager.PuppetEscapes();
        }
    }
}
