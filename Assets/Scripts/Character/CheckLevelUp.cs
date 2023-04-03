/// <summary>
/// Проверка возможности повысить уровень персонажа.
/// </summary>
internal class CheckLevelUp
{
    private int levelValue = Data.CharacterLevelUpExperienceValue;
    internal bool Check(int experience)
    {
        if (CharacterAttributes.experience >= levelValue)
        {
            levelValue = levelValue * 2;

            return true;
        }
        else
            return false;
    }
}