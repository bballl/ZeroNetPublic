using UnityEngine;

public class AgentBulletController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Links links;
    private ParticleSystem destroyParticleSystem;

    private void Awake()
    {
        destroyParticleSystem = Resources.Load<ParticleSystem>("AgentBulletDestroyParticleSystem");
    }

    private void OnEnable()
    {
        float speed = Data.AgentBulletSpeed;
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
    }

    private void OnDisable()
    {
        rb.velocity= Vector3.zero;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            int damage = Data.AgentBulletDefaultDamage;
            Observer.DamageReceivedEvent.Invoke(damage);
        }

        ActivateDestroyParticleSystem();
        links.poolProvider.ReturnToPool(gameObject);
    }

    /// <summary>
    /// Активация эффекта взрыва.
    /// </summary>
    private void ActivateDestroyParticleSystem()
    {
        GameObject.Instantiate(destroyParticleSystem, transform.position, Quaternion.identity);
    }
}
