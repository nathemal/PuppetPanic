using UnityEngine;
using UnityEngine.UIElements;

public class BackButtonController : MonoBehaviour
{
    Button backButton;
    
    public GameObject startMenu;

    private void OnEnable()
    {
        startMenu.SetActive(false);

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
        
        backButton.clicked -= OnAllButtonsClicked;
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

    private void OnAllButtonsClicked() // This runs when any button is clicked so we can add sounds and other stuff that should happen at any button click
    {
        return;
    }
}
