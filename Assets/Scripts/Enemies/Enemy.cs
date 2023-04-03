using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected Links links;

    protected EnemyMovement EnemyMovement;
    protected Rigidbody Rb;
    protected Transform PlayerTransform;

    protected float Speed;
    protected int Defense;
    protected int ContactDamage;
    protected int Experience;

    private PoolProvider poolProvider;
    private ParticleSystem destroyParticleSystem;

    private void Awake()
    {
        BasisInit();
        poolProvider = links.poolProvider;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("CharacterAmmo"))
        {
            DamageCalculation();
        }
        
        if (collision.gameObject.CompareTag("Player"))
        {
            Observer.DamageReceivedEvent.Invoke(ContactDamage);
            GameObjectDestroy();
        }
    }

    /// <summary>
    /// ������� ���������, ����������� ��� ���� ����������� ������ Enemy. 
    /// ��������� ������ �� ���� Rigidbody � Transform ������.
    /// </summary>
    protected void BasisInit()
    {
        Rb = GetComponent<Rigidbody>();
        PlayerTransform = GameObject.FindObjectOfType<PlayerController>().transform;
        destroyParticleSystem = Resources.Load<ParticleSystem>("AgentBulletDestroyParticleSystem");
    }

    /// <summary>
    /// ������ �������� � ������. ������� � ���������� ������, ������� �������� ����. 
    /// </summary>
    protected void MoveToPlayer()
    {
        transform.LookAt(PlayerTransform);
        Rb.AddForce(transform.forward * Time.deltaTime * Speed, ForceMode.Impulse);
    }

    /// <summary>
    /// ������ � ���������� ����������� �����.
    /// </summary>
    private void DamageCalculation()
    {
        var damage = CharacterAttributes.damageValue;
        Defense -= damage;

        if (Defense <= 0)
        {
            Observer.ExperienceReceivedEvent.Invoke(Experience);
            GameObjectDestroy();
        }
    }

    /// <summary>
    /// ����������� ������. ������� � ���.
    /// </summary>
    private void GameObjectDestroy()
    {
        ActivateDestroyParticleSystem();
        poolProvider.ReturnToPool(gameObject);
    }
    
    /// <summary>
    /// ��������� ������� ������.
    /// </summary>
    private void ActivateDestroyParticleSystem()
    {
        GameObject.Instantiate(destroyParticleSystem, transform.position, Quaternion.identity);
    }
}
