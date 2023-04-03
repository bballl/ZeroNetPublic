using UnityEngine;

public sealed class EnemyMovement
{
    private Rigidbody rb;
    private Transform enemyTransform;
    private Transform playerTransform;
    private float speed;

    internal EnemyMovement(Rigidbody rigidbody, Transform transform, float speed)
    {
        rb = rigidbody;
        enemyTransform = transform;
        this.speed = speed;

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    /// <summary>
    /// Логика движения к игроку. Поворот к трансформу игрока, импульс твердому телу. 
    /// </summary>
    internal void MoveToPlayer()
    {
        enemyTransform.LookAt(playerTransform);
        rb.AddForce(enemyTransform.forward * Time.deltaTime * speed, ForceMode.Impulse);
    }
}
