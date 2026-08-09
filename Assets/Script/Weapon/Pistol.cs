using UnityEngine;

public class Pistol : Weapon
{
    protected override void Fire()
    {
        SpawnBullet();
        PlayFireVFX();
        MusicManager.Instance.PlaySound(MusicManager.Instance.FireAudio);
    }
}