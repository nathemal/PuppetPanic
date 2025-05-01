using UnityEngine;
using UnityEngine.UIElements;

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
        return; // TODO: Start the next day here, not sure how we're going to handle that just yet so I'm putting it off for now
    }

    private void OnAllButtonsClicked()
    {
        menuEvents.ButtonClickedEvent();
    }
}
