using Assets.Scripts.Data;
using UnityEngine;

public abstract class AgentGunner : Enemy
{
    protected float WaitTime;
    protected AgentGunnerState CurrentState;
    protected GameObject Bullet;

    protected BulletFactory bulletFactory;

    private void OnEnable()
    {
        bulletFactory = new BulletFactory(BulletType.AgentBullet, links);
    }

    /// <summary>
    /// Получение направления к новой путевой точке и поворот к ней.
    /// </summary>
    protected void GetNewDirection()
    {
        var index = Random.Range(0, AgentGunnerWayPoints.WayPoints.Length);
        var currrentWayPoint = AgentGunnerWayPoints.WayPoints[index];
        transform.LookAt(currrentWayPoint);
    }

    /// <summary>
    /// Движение к путевой точке.
    /// </summary>
    protected void MoveToWayPoint()
    {
        if (CurrentState == AgentGunnerState.Move)
            Rb.AddForce(transform.forward * Time.deltaTime * Speed, ForceMode.Impulse);
    }

    protected void ShootLogic(Transform startBulletPosition)
    {
        GameObject bullet = bulletFactory.Create();
        bullet.transform.position = startBulletPosition.position;
        bullet.transform.rotation = startBulletPosition.rotation;
        bullet.SetActive(true);
    }
}