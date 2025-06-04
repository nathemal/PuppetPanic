using UnityEngine;
using UnityEngine.UIElements;

// This script controls the healthbar in the ui

public class HealthBarUI : MonoBehaviour
{
    VisualElement Heart;

    VisualElement Ticket1;
    VisualElement Ticket2;
    VisualElement Ticket3;
    VisualElement Ticket4;
    VisualElement Ticket5;

    public Texture2D Heart1;
    public Texture2D Heart2;
    public Texture2D Heart3;
    public Texture2D Heart4;
    public Texture2D Heart5;

    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Heart = root.Q<VisualElement>("Heart");

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

                Heart.visible = false;

                // TODO: Trigger the heart breaking animation here
                break;
            case 1:
                Ticket1.visible = true;
                Ticket2.visible = false;
                Ticket3.visible = false;
                Ticket4.visible = false;
                Ticket5.visible = false;

                Heart.style.backgroundImage = new StyleBackground(Heart1);
                break;
            case 2:
                Ticket1.visible = true;
                Ticket2.visible = true;
                Ticket3.visible = false;
                Ticket4.visible = false;
                Ticket5.visible = false;

                Heart.style.backgroundImage = new StyleBackground(Heart2);
                break;
            case 3:
                Ticket1.visible = true;
                Ticket2.visible = true;
                Ticket3.visible = true;
                Ticket4.visible = false;
                Ticket5.visible = false;

                Heart.style.backgroundImage = new StyleBackground(Heart3);
                break;
            case 4:
                Ticket1.visible = true;
                Ticket2.visible = true;
                Ticket3.visible = true;
                Ticket4.visible = true;
                Ticket5.visible = false;

                Heart.style.backgroundImage = new StyleBackground(Heart4);
                break;
            case 5:
                Ticket1.visible = true;
                Ticket2.visible = true;
                Ticket3.visible = true;
                Ticket4.visible = true;
                Ticket5.visible = true;

                Heart.style.backgroundImage = new StyleBackground(Heart5);
                break;
        }
    }
}
