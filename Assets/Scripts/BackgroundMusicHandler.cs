using UnityEngine;

//Script Handles the Backgroud Music, can likely be merged with another script later.
public class BackgroundMusicHandler : MonoBehaviour
{
    public static BackgroundMusicHandler Instance;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        GetComponent<AudioSource>().Play();
    }
}
