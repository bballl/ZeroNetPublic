using UnityEngine;

internal class AgentFactory
{
    private PoolProvider poolProvider;

    private GameObject agentBlueRosePrefab;
    private GameObject agentLilacPrefab;
    private GameObject agentYellowBluePrefab;
    private GameObject agentYellowGunnerPrefab;
    private GameObject agentOrangeGunnerPrefab;

    public AgentFactory(PoolProvider poolProvider)
    {
        this.poolProvider = poolProvider;

        agentBlueRosePrefab = Resources.Load<GameObject>("AgentBlueRose");
        agentLilacPrefab = Resources.Load<GameObject>("AgentLilac");
        agentYellowBluePrefab = Resources.Load<GameObject>("AgentYellowBlue");
        agentYellowGunnerPrefab = Resources.Load<GameObject>("AgentYellowGunner");
        agentOrangeGunnerPrefab = Resources.Load<GameObject>("AgentOrangeGunner");
    }

    public GameObject Create(AgentType type)
    {
        switch (type)
        {
            case AgentType.AgentBlueRose:
                return poolProvider.Create(agentBlueRosePrefab);
            case AgentType.AgentLilac:
                return poolProvider.Create(agentLilacPrefab);
            case AgentType.AgentYellowBlue:
                return poolProvider.Create(agentYellowBluePrefab);
            case AgentType.AgentYellowGunner:
                return poolProvider.Create(agentYellowGunnerPrefab);
            case AgentType.AgentOrangeGunner:
                return poolProvider.Create(agentOrangeGunnerPrefab);
            default: 
                Debug.Log("Ошибка создания агента.");
                return null;
        }
    }
}