using UnityEngine;
using UnityEngine.UIElements;

public class StartMenuController : MonoBehaviour
{
    Button startButton;
    Button controlsButton;
    Button creditsButton;

    Button[] allButtons = new Button[3];

    private void Awake()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        startButton = root.Q<Button>("StartButton");
        controlsButton = root.Q<Button>("ControlsButton");
        creditsButton = root.Q<Button>("CreditsButton");

        allButtons[0] = startButton;
        allButtons[1] = controlsButton;
        allButtons[2] = creditsButton;
    }

    private void OnEnable()
    {
        ButtonActionsSubscribe();

        startButton.Focus();
    }

    private void OnDisable()
    {
        ButtonActionsUnsubscribe();
    }

    private void ButtonActionsSubscribe()
    {
        startButton.clicked += OnStartButtonClicked;
        controlsButton.clicked += OnControlsButtonClicked;
        creditsButton.clicked += OnCreditsButtonClicked;

        foreach (Button button in allButtons)
        {
            button.clicked += OnAllButtonsClicked;
        }
    }

    private void ButtonActionsUnsubscribe()
    {
        startButton.clicked -= OnStartButtonClicked;
        controlsButton.clicked -= OnControlsButtonClicked;
        creditsButton.clicked -= OnCreditsButtonClicked;

        foreach (Button button in allButtons)
        {
            button.clicked -= OnAllButtonsClicked;
        }
    }

    // The code bellow this comment is mostly placeholders that will be replaced with the actual functions of the buttons later
    private void OnStartButtonClicked() => ButtonClickedEvent("Start");
    private void OnControlsButtonClicked() => ButtonClickedEvent("Controls");
    private void OnCreditsButtonClicked() => ButtonClickedEvent("Credits");

    private void OnAllButtonsClicked()
    {
        // This runs when any button is clicked so we can add sounds and other stuff that should happen at any button click
    }

    private void ButtonClickedEvent(string buttonType)
    {
        Debug.Log(buttonType + " Button was clicked");
    }
}
