using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultGameMenuController : MonoBehaviour
{
    [SerializeField] private Button menuButton;
    [SerializeField] private Text textPanelText;

    private void Awake()
    {
        textPanelText.text = GetResultText();
        menuButton.onClick.AddListener(() => LoadMainMenu());
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene((int)Scenes.MainMenu);
    }

    /// <summary>
    /// Получить текст, соответствующий результату игровой сессии.
    /// </summary>
    /// <returns></returns>
    private string GetResultText()
    {
        if (GameSessionResult.IsGameWin)
            return MenuText.ResultWinMenuText; 
        else
            return MenuText.ResultLoseMenuText;
    }
}
