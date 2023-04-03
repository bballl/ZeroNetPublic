using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Висит на GameController.
/// </summary>
public class SpawnController : MonoBehaviour
{
    [SerializeField] private Links links;
    
    private List<Transform> spawnPoints;
    private AgentFactory agentFactory;
    private Coroutine coroutine;
    private float spawnWaitTime = Data.SpawnWaitTime;

    private void Awake()
    {
        agentFactory = new AgentFactory(links.poolProvider);
        GetAllSpawnPoints();
    }

    private void Start()
    {
        coroutine = StartCoroutine(SpawnStart());
    }

    /// <summary>
    /// Стартует процесс появления нового агента.
    /// </summary>
    private IEnumerator SpawnStart()
    {
        Spawn();
        yield return new WaitForSeconds(spawnWaitTime);
        if (spawnWaitTime > Data.SpawnMinTime)
            spawnWaitTime -= Data.SpawnTimeReduction;

        coroutine = null; // перестраховываемся, чтобы не плодить короутины
        coroutine = StartCoroutine(SpawnStart());
    }

    /// <summary>
    /// Появление нового агента в одной из SpawnPoint.
    /// </summary>
    private void Spawn()
    {
        var index = Random.Range(0, spawnPoints.Count);
        var spawnPoint = spawnPoints[index];

        var agentType = GetNextAgentType();
        if (agentType == AgentType.None)
        {
            Debug.Log("Ошибка при выполнении Spawn");
            return;
        }

        GameObject agent = agentFactory.Create(agentType);
        agent.transform.position = spawnPoint.transform.position;
        agent.transform.rotation = Quaternion.identity; //?
        agent.SetActive(true);
    }

    /// <summary>
    /// Получает все SpawnPoints и сохраняет их в List.
    /// </summary>
    private void GetAllSpawnPoints()
    {
        var spawnPointsGameObjects = GameObject.FindGameObjectsWithTag("SpawnPoint");
        spawnPoints = new List<Transform>();

        foreach (var e in spawnPointsGameObjects)
        {
            spawnPoints.Add(e.transform);
        }
    }

    /// <summary>
    /// Получить противника случайного типа для спавна.
    /// </summary>
    private AgentType GetNextAgentType()
    {
        var maxIndex = (int)AgentType.None;
        var index = Random.Range(0, maxIndex);

        
        
        //string name = null;
        switch (index)
        {
            case (int)AgentType.AgentBlueRose:
                return AgentType.AgentBlueRose;

            case (int)AgentType.AgentLilac:
                return AgentType.AgentLilac;

            case (int)AgentType.AgentYellowBlue:
                return AgentType.AgentYellowBlue;

            case (int)AgentType.AgentYellowGunner:
                return AgentType.AgentYellowGunner;

            case (int)AgentType.AgentOrangeGunner:
                return AgentType.AgentOrangeGunner;

            default:
                return AgentType.None;
        }
    }
}
