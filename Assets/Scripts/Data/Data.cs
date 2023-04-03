/// <summary>
/// Хранит стартовые значения основных атрибутов.
/// </summary>
internal struct Data
{
    //персонаж
    public static readonly float CharacterRotationSpeed = 10f;
    public static readonly int CharacterSpeed = 5;
    public static readonly int CharacterDefense = 200;
    public static readonly int CharacterLevelUpExperienceValue = 150;

    //оружие персонажа
    public static readonly int BulletSpeed = 1;
    public static readonly int BulletDefaultDamage = 5;

    //противники
    public static readonly float AgentYellowBlueSpeed = 2.5f;
    public static readonly int AgentYellowBlueDefense = 21;
    public static readonly int AgentYellowBlueContactDamage = 3;
    public static readonly int AgentYellowBlueExperience = 2;

    public static readonly float AgentBlueRoseSpeed = 4.5f;
    public static readonly int AgentBlueRoseDefense = 10;
    public static readonly int AgentBlueRoseContactDamage = 1;
    public static readonly int AgentBlueRoseExperience = 1;

    public static readonly float AgentLilacSpeed = 2f;
    public static readonly int AgentLilacDefense = 48;
    public static readonly int AgentLilacContactDamage = 1;
    public static readonly int AgentLilacExperience = 2;

    public static readonly float AgentYellowGunnerSpeed = 12.7f;
    public static readonly int AgentYellowGunnerDefense = 25;
    public static readonly int AgentYellowGunnerContactDamage = 1;
    public static readonly int AgentYellowGunnerExperience = 3;

    public static readonly float AgentOrangewGunnerSpeed = 13.7f;
    public static readonly int AgentOrangeGunnerDefense = 15;
    public static readonly int AgentOrangewGunnerContactDamage = 1;
    public static readonly int AgentOrangewGunnerExperience = 5;

    //снаряды противников
    public static readonly int AgentBulletSpeed = 20;
    public static readonly int AgentBulletDefaultDamage = 5;

    //spawn
    public static readonly float SpawnWaitTime = 2.5f;
    public static readonly float SpawnMinTime = 0.3f;
    public static readonly float SpawnTimeReduction = 0.005f;

    //способности персонажа
    public static readonly int ExtraDefense = 50;
    public static readonly int ExtraDamage = 2;
    public static readonly int RegenerationValue = 2;
    public static readonly int QuickExperienceValue = 2;
    public static readonly float QuickFindValue = 0.005f;

    //игровая сессия
    public static readonly float GameSessionMaxTime = 570f;
}