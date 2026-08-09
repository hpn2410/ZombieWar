using UnityEngine;

public class RifleVFX : WeaponVFX
{
    public override void PlayFireVFX()
    {
        muzzleFlash.Play();
        shellEject.Play();
    }
}
