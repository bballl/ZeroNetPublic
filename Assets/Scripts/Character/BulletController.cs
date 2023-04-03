using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Links links;
    private ParticleSystem contactParticleSystem;

    private void Awake()
    {
        contactParticleSystem = Resources.Load<ParticleSystem>("BulletDestroyParticleSystem");
    }

    private void OnEnable()
    {
        rb.AddForce(transform.forward * Data.BulletSpeed, ForceMode.Impulse);
    }

    private void OnDisable()
    {
        rb.velocity = Vector3.zero;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject.Instantiate(contactParticleSystem, transform.position, Quaternion.identity);
        links.poolProvider.ReturnToPool(gameObject);
        //Observer.BulletReturnToPoolEvent(gameObject);
    }
}
