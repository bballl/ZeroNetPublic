using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour 
{
    [SerializeField] private Text defenseValueText;
    [SerializeField] private Text experienceValueText;
    [SerializeField] private Text timerText;
    [SerializeField] private Text infoText;
    [SerializeField] private Text accompanyingText;

    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject abilitiesPanel;
    
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button menuButton;
    [SerializeField] private Button backButton;
    
    [SerializeField] private Button extraDefenseAbilityButton;
    [SerializeField] private Button extraDamageAbilityButton;
    [SerializeField] private Button regenerationAbilityButton;
    [SerializeField] private Button quickFindAbilityButton;
    [SerializeField] private Button quickExperienceAbilityButton;

    private bool isStartingAbilitySelection;

    private void Awake()
    {
        pausePanel.SetActive(false);
        backButton.gameObject.SetActive(false);

        pauseButton.onClick.AddListener(() => OpenPauseMenu());
        backButton.onClick.AddListener(() => ClosePanel());
        menuButton.onClick.AddListener(() => LoadMainMenu());

        extraDefenseAbilityButton.onClick.AddListener(() => ChooseAbility(AbilityType.ExtraDefense));
        extraDamageAbilityButton.onClick.AddListener(() => ChooseAbility(AbilityType.ExtraDamage));
        regenerationAbilityButton.onClick.AddListener(() => ChooseAbility(AbilityType.Regeneration));
        quickFindAbilityButton.onClick.AddListener(() => ChooseAbility(AbilityType.QuckFind));
        quickExperienceAbilityButton.onClick.AddListener(() => ChooseAbility(AbilityType.QuickExperience));

        Observer.UIDataUpdateEvent += ChangeDataView;
        Observer.AbilitySelectionEvent += OpenAbilitiesPanel;

        defenseValueText.text = "Защита: " + Data.CharacterDefense.ToString();
    }

    private void Start()
    {
        if (isStartingAbilitySelection == false)
        {
            OpenAbilitiesPanel();
            isStartingAbilitySelection = true;
        }
    }

    private void FixedUpdate()
    {
        timerText.text = Mathf.Round(CurrentGameSessionTime.time).ToString();
    }

    private void OnDestroy()
    {
        Observer.UIDataUpdateEvent -= ChangeDataView;
        Observer.AbilitySelectionEvent -= OpenAbilitiesPanel;
    }

    /// <summary>
    /// Обновление текста панелей UI.
    /// </summary>
    private void ChangeDataView()
    {
        defenseValueText.text = "Защита: " + CharacterAttributes.defense.ToString();
        experienceValueText.text = "Опыт: " + CharacterAttributes.experience.ToString();
    }

    /// <summary>
    /// Ставит игру на паузу, открывает меню паузы.
    /// </summary>
    private void OpenPauseMenu()
    {
        backButton.gameObject.SetActive(true);
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    /// <summary>
    /// Ставит игру на паузу, открывает меню выбора способностей.
    /// </summary>
    private void OpenAbilitiesPanel()
    {
        backButton.gameObject.SetActive(true);
        abilitiesPanel.SetActive(true);
        Time.timeScale = 0;
    }

    /// <summary>
    /// Снимает игру с паузы, закрывает открытые панели.
    /// </summary>
    private void ClosePanel()
    {
        backButton.gameObject.SetActive(false);
        pausePanel.SetActive(false);
        abilitiesPanel.SetActive(false);
        Time.timeScale = 1;
    }

    /// <summary>
    /// Выбрать способность.
    /// </summary>
    private void ChooseAbility(AbilityType type)
    {
        accompanyingText.text = "Повышение уровня!";
        Observer.AbilitiyApplyEvent.Invoke(type);

        switch (type)
        {
            case AbilityType.ExtraDefense:
                extraDefenseAbilityButton.onClick.RemoveAllListeners();
                extraDefenseAbilityButton.GetComponentInChildren<Text>().text = "Выбрано";
                break;

            case AbilityType.ExtraDamage:
                extraDamageAbilityButton.onClick.RemoveAllListeners();
                extraDamageAbilityButton.GetComponentInChildren<Text>().text = "Выбрано";
                break;

            case AbilityType.Regeneration:
                regenerationAbilityButton.onClick.RemoveAllListeners();
                regenerationAbilityButton.GetComponentInChildren<Text>().text = "Выбрано";
                break;

            case AbilityType.QuckFind:
                quickFindAbilityButton.onClick.RemoveAllListeners();
                quickFindAbilityButton.GetComponentInChildren<Text>().text = "Выбрано";
                break;

            case AbilityType.QuickExperience:
                quickExperienceAbilityButton.onClick.RemoveAllListeners();
                quickExperienceAbilityButton.GetComponentInChildren<Text>().text = "Выбрано";
                break;
        }

        ClosePanel();
    }

    /// <summary>
    /// Загрузка сцены главного меню игры.
    /// </summary>
    private void LoadMainMenu()
    {
        SceneManager.LoadScene((int)Scenes.MainMenu);
    }
}
