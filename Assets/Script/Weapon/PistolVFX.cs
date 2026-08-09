using UnityEngine;

public class PistolVFX : WeaponVFX
{
    public override void PlayFireVFX()
    {
        muzzleFlash.Play();
        shellEject.Play();
    }
}
