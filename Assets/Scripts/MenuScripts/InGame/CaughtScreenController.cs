using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class CaughtScreenController : MonoBehaviour
{
    Button nextDayButton;

    public MenuEvents menuEvents;

    private void OnEnable()
    {
        InitializeUiToolkit();
        ButtonActionsSubscribe();

        nextDayButton.Focus();
    }

    private void OnDisable()
    {
        ButtonActionsUnsubscribe();
    }

    private void InitializeUiToolkit()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        nextDayButton = root.Q<Button>("NextDayButton");
    }

    private void ButtonActionsSubscribe()
    {
        nextDayButton.clicked += OnNextDayButtonClicked;
        nextDayButton.clicked += OnAllButtonsClicked;
    }

    private void ButtonActionsUnsubscribe()
    {
        nextDayButton.clicked -= OnNextDayButtonClicked;
        nextDayButton.clicked -= OnAllButtonsClicked;
    }

    private void OnNextDayButtonClicked()
    {
        SceneManager.LoadScene("Room 1");
    }

    private void OnAllButtonsClicked()
    {
        menuEvents.ButtonClickedEvent();
    }
}
