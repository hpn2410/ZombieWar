using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected float fireRate = 5f;

    private float nextFireTime;

    public abstract WeaponType Type { get; }

    public bool TryFire()
    {
        if (Time.time < nextFireTime)
            return false;

        nextFireTime = Time.time + 1f / fireRate;

        Fire();
        return true;
    }

    protected abstract void Fire();
}