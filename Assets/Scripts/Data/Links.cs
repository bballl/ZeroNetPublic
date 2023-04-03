using UnityEngine;

[CreateAssetMenu(fileName = "Links", menuName = "Data/Links")]
public class Links : ScriptableObject
{
    internal PoolProvider poolProvider = new PoolProvider();
}