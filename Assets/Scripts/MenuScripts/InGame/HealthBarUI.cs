using UnityEngine;
using UnityEngine.UIElements;

public class HealthBarUI : MonoBehaviour
{
    VisualElement Ticket1;
    VisualElement Ticket2;
    VisualElement Ticket3;
    VisualElement Ticket4;
    VisualElement Ticket5;

    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Ticket1 = root.Q<VisualElement>("Ticket1");
        Ticket2 = root.Q<VisualElement>("Ticket2");
        Ticket3 = root.Q<VisualElement>("Ticket3");
        Ticket4 = root.Q<VisualElement>("Ticket4");
        Ticket5 = root.Q<VisualElement>("Ticket5");

        UpdateHealthBar();
    }

    public void UpdateHealthBar() // This function needs to be called every time health is updated
    {
        MainManager.currentHealth = Mathf.Clamp(MainManager.currentHealth, 0, MainManager.maxHealth); // This makes sure that the health remains within 0 and MaxHealth

        switch (MainManager.currentHealth) // The number in the case is the current HP the player has
        {
            case 0:
                Ticket1.visible = false;
                Ticket2.visible = false;
                Ticket3.visible = false;
                Ticket4.visible = false;
                Ticket5.visible = false;
                break;
            case 1:
                Ticket1.visible = true;
                Ticket2.visible = false;
                Ticket3.visible = false;
                Ticket4.visible = false;
                Ticket5.visible = false;
                break;
            case 2:
                Ticket1.visible = true;
                Ticket2.visible = true;
                Ticket3.visible = false;
                Ticket4.visible = false;
                Ticket5.visible = false;
                break;
            case 3:
                Ticket1.visible = true;
                Ticket2.visible = true;
                Ticket3.visible = true;
                Ticket4.visible = false;
                Ticket5.visible = false;
                break;
            case 4:
                Ticket1.visible = true;
                Ticket2.visible = true;
                Ticket3.visible = true;
                Ticket4.visible = true;
                Ticket5.visible = false;
                break;
            case 5:
                Ticket1.visible = true;
                Ticket2.visible = true;
                Ticket3.visible = true;
                Ticket4.visible = true;
                Ticket5.visible = true;
                break;
        }
    }
}
