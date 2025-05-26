using UnityEngine;
using UnityEngine.UIElements;

public class HealthBarUI : MonoBehaviour
{
    private VisualElement healthFill;

    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        healthFill = root.Q<VisualElement>("HealthFill");

        UpdateHealthBar();
    }

    public void SetHealth(float newHealth) // This function needs to be called every time health is updated
    {
        MainManager.currentHealth = Mathf.Clamp(newHealth, 0, MainManager.maxHealth); // This makes sure that the health remains within 0 and MaxHealth
        
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        float percentage = (MainManager.currentHealth / MainManager.maxHealth) * 100; // TODO: Replace Manager with MainManager when merged.
        healthFill.style.width = Length.Percent(percentage);
    }
}
