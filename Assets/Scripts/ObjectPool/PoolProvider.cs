using System.Collections.Generic;
using UnityEngine;

public class PoolProvider
{
    private static readonly Dictionary<string, ObjectPool> providerCache
        = new Dictionary<string, ObjectPool>();

    /// <summary>
    /// Если нет нужного пула объектов, создает его. Запускает метод Pop в пуле.
    /// </summary>
    public GameObject Create(GameObject prefab)
    {
        if (!providerCache.TryGetValue(prefab.name, out ObjectPool viewPool)) //проверяем, есть ли в словаре префаб с таким именем
        {
            viewPool = new ObjectPool(prefab);
            providerCache[prefab.name] = viewPool; //добавляем элемент в словарь
        }

        return viewPool.Pop();
    }

    /// <summary>
    /// Инициирует перемещение объекта в пул.
    /// </summary>
    public void ReturnToPool(GameObject prefab)
    {
        if (providerCache.ContainsKey(prefab.name))
            providerCache[prefab.name].Push(prefab);
        else
            GameObject.Destroy(prefab);
        
    }
}