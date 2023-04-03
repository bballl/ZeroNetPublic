using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform startBulletPositionLeft;
    [SerializeField] private Transform startBulletPositionRight;
    [SerializeField] private Links links;

    private Rigidbody rb;
    private ParticleSystem[] bulletStartParticleSystem;
    private AudioSource audioSource;
    private CharacterMovement characterMovement;
    private CharacterShooting characterShooting;
    private InputController inputController;
    private Regeneration regeneration;
    private CheckLevelUp levelUp;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        bulletStartParticleSystem = GetComponentsInChildren<ParticleSystem>();
        
        inputController = new InputController();
        characterMovement = new CharacterMovement(transform, rb);
        characterShooting = new CharacterShooting(startBulletPositionLeft, startBulletPositionRight, 
            bulletStartParticleSystem, links);
        regeneration = new Regeneration();
        levelUp = new CheckLevelUp();

        Observer.DamageReceivedEvent += GetDamage;
        Observer.ExperienceReceivedEvent += GetExperience;
    }
    private void Update()
    {
        characterMovement.Move();
        Shooting();
    }

    private void FixedUpdate()
    {
        Regeneration();
    }

    private void OnDestroy()
    {
        Observer.DamageReceivedEvent -= GetDamage;
        Observer.ExperienceReceivedEvent -= GetExperience;
    }

    /// <summary>
    /// Активация стрельбы.
    /// </summary>
    private void Shooting()
    {
        if (inputController.GetFireButtonFirst())
        {
            characterShooting.Shot();
            audioSource.Play();
        }
    }

    /// <summary>
    /// Получение урона
    /// </summary>
    private void GetDamage(int damage)
    {
        CharacterAttributes.defense -= damage;
        Observer.UIDataUpdateEvent.Invoke();

        if (CharacterAttributes.defense <= 0)
            Observer.EndGameEvent.Invoke(false);
    }

    /// <summary>
    /// Получение опыта.
    /// </summary>
    private void GetExperience(int experience)
    {
        CharacterAttributes.experience += experience;
        
        if (CharacterAttributes.isQuicExperience)
            CharacterAttributes.experience += Data.QuickExperienceValue;

        CheckLevelUp();
        Observer.UIDataUpdateEvent.Invoke();
    }

    /// <summary>
    /// Регенерация.
    /// </summary>
    private void Regeneration()
    {
        if (CharacterAttributes.isRegeneration)
        {
            bool result = regeneration.TryRegeneration(Time.deltaTime);
            if (result)
            {
                CharacterAttributes.defense += Data.RegenerationValue;
                Observer.UIDataUpdateEvent.Invoke();
            }
        }
    }

    /// <summary>
    /// Проверка выполнения условий повышения уровня. 
    /// Если условия выполнены, повышается уровень персонажа и стартует выбор новой способности.
    /// </summary>
    private void CheckLevelUp()
    {
        var result =  levelUp.Check(CharacterAttributes.experience);
        
        if (result)
            Observer.AbilitySelectionEvent.Invoke();
    }
}
