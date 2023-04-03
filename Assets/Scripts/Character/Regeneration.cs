using UnityEngine;

/// <summary>
/// Класс, отвечающий за регенерацию защиты.
/// </summary>
internal class Regeneration
{
    private int maxValue = 3;
    private float maxTime = 3f;
    private float currentTime;

    /// <summary>
    /// Случайным образом определяет, состоялась ли регенерация.
    /// </summary>
    /// <returns>true, если регенерация состоялась.</returns>
    internal bool TryRegeneration(float deltaTime)
    {
        if (Timer(deltaTime))
        {
            var value = Random.Range(0, maxValue + 1);

            if (value == maxValue)
                return true;
            else
                return false;
        }

        return false;
    }

    /// <summary>
    /// Таймер регенерации.
    /// </summary>
    /// <returns>true, если сработал таймер.</returns>
    private bool Timer(float deltaTime)
    {
        if (currentTime < maxTime)
        {
            currentTime += deltaTime;
            return false;
        }
        else
        {
            currentTime = 0;
            return true;
        }
    }
}