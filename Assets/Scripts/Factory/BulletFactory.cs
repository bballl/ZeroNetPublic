using UnityEngine;

public class BulletFactory
{
    private GameObject bulletPrefab;
    private PoolProvider poolProvider;

    internal BulletFactory(BulletType type, Links links)
    {
        poolProvider = links.poolProvider;

        if (type == BulletType.CharacterBullet)
            bulletPrefab = Resources.Load("Bullet") as GameObject;

        if (type == BulletType.AgentBullet)
        {
            bulletPrefab = Resources.Load("AgentBullet") as GameObject;
        }
    }

    public GameObject Create()
    {
        return poolProvider.Create(bulletPrefab);
    }
}