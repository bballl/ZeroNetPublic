using UnityEngine;

namespace Assets.Scripts.Data
{
    public struct AgentGunnerWayPoints
    {
        public static readonly Vector3[] WayPoints = 
        { 
            new Vector3(0, 0, 0),
            new Vector3(90, 0, 90),
            new Vector3(90, 0, -90),
            new Vector3(-90, 0, -90),
            new Vector3(-90, 0, 90)
        };
    }
}
