using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public GameObject WinScreen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        WinScreen.SetActive(true);
    }
}
