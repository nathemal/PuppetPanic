using UnityEngine;
using UnityEngine.UIElements;

public class BackButtonController : MonoBehaviour
{
    Button backButton;
    
    public GameObject startMenu;
    private MenuEvents menuEvents;

    private void OnEnable()
    {
        startMenu.SetActive(false);

        menuEvents = startMenu.GetComponent<MenuEvents>();

        InitializeUiToolkit();
        ButtonActionsSubscribe();

        backButton.Focus();
    }

    private void OnDisable()
    {
        ButtonActionsUnsubscribe();
    }

    private void InitializeUiToolkit()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        backButton = root.Q<Button>("BackButton");
    }

    private void ButtonActionsSubscribe()
    {
        backButton.clicked += OnBackButtonClicked;
        
        backButton.clicked += OnAllButtonsClicked;
    }

    private void ButtonActionsUnsubscribe()
    {
        backButton.clicked -= OnBackButtonClicked;

        backButton.clicked -= OnAllButtonsClicked;
    }

    private void OnBackButtonClicked()
    {
        startMenu.SetActive(true);
    }

    private void OnAllButtonsClicked()
    {
        menuEvents.ButtonClickedEvent();
    }
}
