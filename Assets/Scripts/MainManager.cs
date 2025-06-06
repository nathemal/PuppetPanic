using UnityEngine;

public class MainManager : MonoBehaviour
{
    public const float maxHealth = 5;
    public static float currentHealth = 5;
    public static int objectCounter = 0;

    public static bool inventoryActive;
    public static bool featherCollected;
    public static bool gemCollected;
    public static bool furCollected;
    public static bool ringCollected;
    public static bool flowerCollected;
    
    public const float maxTime = 300; 
    // TODO: Change this variable to the desire timer lenght
    public static float remainingTime = maxTime; 
}
