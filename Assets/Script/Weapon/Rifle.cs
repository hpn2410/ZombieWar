using UnityEngine;

public class Rifle : Weapon
{
    protected override void Fire()
    {
        SpawnBullet();
        PlayFireVFX();
    }
}