using UnityEngine;

/// <summary>
/// Класс отвечает за логику стрельбы.
/// </summary>
internal sealed class CharacterShooting
{
    private BulletFactory bulletFactory;
    private Transform startBulletPositionLeft;
    private Transform startBulletPositionRight;
    private ParticleSystem[] bulletStartParticleSystem;


    internal CharacterShooting(Transform startBulletPositionLeft, Transform startBulletPositionRight, 
        ParticleSystem[] bulletStartParticleSystem, Links links)
    {
        this.bulletStartParticleSystem = bulletStartParticleSystem;
        this.startBulletPositionLeft = startBulletPositionLeft;
        this.startBulletPositionRight= startBulletPositionRight;
        
        bulletFactory = new BulletFactory(BulletType.CharacterBullet, links);
    }
    
    public void Shot()
    {
        ActivateBulletStartParticleSystem(bulletStartParticleSystem);
        ShootLogic(startBulletPositionLeft, startBulletPositionRight);
    }
    
    /// <summary>
    /// Логика стрельбы.
    /// </summary>
    /// <param name="startBulletPositionLeft">Позиция создания пули левого орудия.</param>
    /// <param name="startBulletPositionRight">Позиция создания пули правого орудия.</param>
    private void ShootLogic(Transform startBulletPositionLeft, Transform startBulletPositionRight)
    {
        GameObject bullet = bulletFactory.Create();
        bullet.transform.position = startBulletPositionLeft.position;
        bullet.transform.rotation = startBulletPositionLeft.rotation;
        bullet.SetActive(true);

        bullet = bulletFactory.Create();
        bullet.transform.position = startBulletPositionRight.position;
        bullet.transform.rotation = startBulletPositionRight.rotation;
        bullet.SetActive(true);
    }

    /// <summary>
    /// Активация связанной с выстрелом ParticleSystem.
    /// </summary>
    private void ActivateBulletStartParticleSystem(ParticleSystem[] bulletStartParticleSystem)
    {
        foreach (var particle in bulletStartParticleSystem)
        {
            particle.Play();
        }
    }
}