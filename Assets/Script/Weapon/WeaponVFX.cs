using UnityEngine;

public abstract class WeaponVFX : MonoBehaviour
{
    [SerializeField] protected ParticleSystem muzzleFlash;
    [SerializeField] protected ParticleSystem shellEject;

    public abstract void PlayFireVFX();
}