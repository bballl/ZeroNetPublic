using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject TextPanel;
    
    [SerializeField] private Button prologButton;
    [SerializeField] private Button startGameButton;
    [SerializeField] private Button controlButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button backButton;
    
    [SerializeField] private Text textPanelText;

    private void Awake()
    {
        TextPanel.SetActive(false);
        backButton.gameObject.SetActive(false);
        
        prologButton.onClick.AddListener(() => OpenTextPanel(MenuText.PrologText));
        controlButton.onClick.AddListener(() => OpenTextPanel(MenuText.ControlText));
        startGameButton.onClick.AddListener(() => StartGame());
        exitButton.onClick.AddListener(() => Exit());
        backButton.onClick.AddListener(() => BackToMainMenu());
    }

    /// <summary>
    /// Показать инструкцию по управлению в игре.
    /// </summary>
    private void OpenTextPanel(string text)
    {
        mainMenuPanel.SetActive(false);
        TextPanel.SetActive(true);
        backButton.gameObject.SetActive(true);
        textPanelText.text = text;
    }

    /// <summary>
    /// Переход к сцене GameLevel.
    /// </summary>
    private void StartGame()
    {
        SceneManager.LoadScene((int)Scenes.GameLevel);
    }

    /// <summary>
    /// Возврат в главное меню.
    /// </summary>
    private void BackToMainMenu()
    {
        TextPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
        backButton.gameObject.SetActive(false);
    }

    private void Exit()
    {
        Application.Quit();
    }
}
