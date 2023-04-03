using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Висит на GameController.
/// </summary>
public class GameStateController : MonoBehaviour
{
    private void Start()
    {
        CharacterAttributes.SetDefaultAttributesValues();
        CurrentGameSessionTime.time = Data.GameSessionMaxTime;
        Observer.EndGameEvent += EndGame;
    }

    private void FixedUpdate()
    {
        WinTimer();
    }

    private void OnDestroy()
    {
        Observer.EndGameEvent -= EndGame;
    }
    
    /// <summary>
    /// Окончание игровой сессии. isGameWin в значении true соответствует победе.
    /// </summary>
    private void EndGame(bool isGameWin)
    {
        GameSessionResult.IsGameWin = isGameWin;
        SceneManager.LoadScene((int)Scenes.ResultGameMenu);
    }

    /// <summary>
    /// Таймер обратного отсчета игровой сессии. При обнулении присуждается победа.
    /// </summary>
    private void WinTimer()
    {
        CurrentGameSessionTime.time -= Time.deltaTime;

        if (CharacterAttributes.isQuickFind)
            CurrentGameSessionTime.time -= Data.QuickFindValue;

        if (CurrentGameSessionTime.time <= 0)
            EndGame(true);
    }
}
