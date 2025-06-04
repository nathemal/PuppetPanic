using UnityEngine;

public class MainManager : MonoBehaviour
{
    public const float maxHealth = 5;
    public static float currentHealth = 5;
    public static int objectCounter = 0;

    public const float maxTime = 100; // TODO: Change this variable to the desire timer lenght
    public static float remainingTime = maxTime; 
}
