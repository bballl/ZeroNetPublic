internal static class CharacterAttributes
{
    internal static float rotationSpeed = Data.CharacterRotationSpeed;
    internal static int speed = Data.CharacterSpeed;
    internal static int defense = Data.CharacterDefense;
    internal static int damageValue = Data.BulletDefaultDamage;
    internal static int experience;
    internal static bool isRegeneration;
    internal static bool isQuickFind;
    internal static bool isQuicExperience;

    static CharacterAttributes()
    {
        Observer.AbilitiyApplyEvent += AbilityApply;
    }
    
    /// <summary>
    /// Присвоение дефолтных значение характеристикам персонажа.
    /// </summary>
    internal static void SetDefaultAttributesValues()
    {
        rotationSpeed = Data.CharacterRotationSpeed;
        speed = Data.CharacterSpeed;
        defense = Data.CharacterDefense;
        damageValue = Data.BulletDefaultDamage;
        experience = 0;
        isRegeneration = false;
        isQuickFind = false;
        isQuicExperience = false;
    }
    
    internal static int GetDamageValue()
    {
        return damageValue;
    }

    /// <summary>
    /// Получение новой способности.
    /// </summary>
    private static void AbilityApply(AbilityType type)
    {
        switch (type)
        {
            case AbilityType.ExtraDefense:
                defense += Data.ExtraDefense;
                break;

            case AbilityType.ExtraDamage:
                damageValue += Data.ExtraDamage;
                break;

            case AbilityType.Regeneration:
                isRegeneration = true;
                break;

            case AbilityType.QuckFind:
                isQuickFind = true;
                break;

            case AbilityType.QuickExperience:
                isQuicExperience = true;
                break;
        }
    }

    /// <summary>
    /// Отписка от делегатов.
    /// </summary>
    internal static void Unsubscribe()
    {
        Observer.AbilitiyApplyEvent -= AbilityApply;
    }
}