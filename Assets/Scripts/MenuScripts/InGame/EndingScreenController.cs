using UnityEngine;
using UnityEngine.UIElements;

public class EndingScreenController : MonoBehaviour
{
    Button playAgainButton;
    Button mainMenuButton;

    Button[] allButtons = new Button[2];

    public MenuEvents menuEvents;

    private string mainMenu = "MainMenu";
    private string startGame = "Room 1"; // TODO: Replace SampleScene with the name of the first game scene

    private void OnEnable()
    {
        InitializeUiToolkit();
        ButtonActionsSubscribe();
    }

    private void OnDisable()
    {
        ButtonActionsUnsubscribe();
    }

    private void InitializeUiToolkit()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        playAgainButton = root.Q<Button>("PlayAgainButton");
        mainMenuButton = root.Q<Button>("MainMenuButton");

        allButtons[0] = playAgainButton;
        allButtons[1] = mainMenuButton;
    }

    private void ButtonActionsSubscribe()
    {
        playAgainButton.clicked += PlayAgainButtonClicked;
        mainMenuButton.clicked += MainMenuButtonClicked;

        foreach (Button button in allButtons)
        {
            button.clicked += OnAllButtonsClicked;
        }
    }

    private void ButtonActionsUnsubscribe()
    {
        playAgainButton.clicked -= PlayAgainButtonClicked;
        mainMenuButton.clicked -= MainMenuButtonClicked;

        foreach (Button button in allButtons)
        {
            button.clicked -= OnAllButtonsClicked;
        }
    }

    private void PlayAgainButtonClicked()
    {
        menuEvents.LoadScene(startGame);
        Manager.ResetGame();
    }

    private void MainMenuButtonClicked()
    {
        menuEvents.LoadScene(mainMenu);
        Manager.ResetGame();
    }

    private void OnAllButtonsClicked()
    {
        menuEvents.ButtonClickedEvent();
    }
}
