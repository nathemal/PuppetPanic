using UnityEngine;
using UnityEngine.UIElements;

public class StartMenuController : MonoBehaviour
{
    Button startButton;
    Button controlsButton;
    Button creditsButton;

    Button[] allButtons = new Button[3];

    public GameObject controlsScreen;
    public GameObject creditsScreen;

    private MenuEvents menuEvents;
    private string startGame = "Room 1"; // TODO: Replace SampleScene with the name of the first game scene

    private void OnEnable()
    {
        controlsScreen.SetActive(false);
        creditsScreen.SetActive(false);
        
        menuEvents = GetComponent<MenuEvents>();

        InitializeUiToolkit();
        ButtonActionsSubscribe();

        startButton.Focus();
    }

    private void OnDisable()
    {
        ButtonActionsUnsubscribe();
    }

    private void InitializeUiToolkit()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        startButton = root.Q<Button>("StartButton");
        controlsButton = root.Q<Button>("ControlsButton");
        creditsButton = root.Q<Button>("CreditsButton");

        allButtons[0] = startButton;
        allButtons[1] = controlsButton;
        allButtons[2] = creditsButton;
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

    private void OnStartButtonClicked()
    {
        menuEvents.LoadScene(startGame);
    }

    private void OnControlsButtonClicked()
    {
        controlsScreen.SetActive(true);
    }

    private void OnCreditsButtonClicked()
    {
        creditsScreen.SetActive(true);
    }

    private void OnAllButtonsClicked()
    {
        menuEvents.ButtonClickedEvent();
    }
}
