using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected WeaponData weaponData;
    [SerializeField] protected Transform firePoint;
    [SerializeField] protected ObjectPool bulletPool;

    private float nextFireTime;

    public WeaponType Type => weaponData.type;

    public bool TryFire()
    {
        if (Time.time < nextFireTime)
            return false;

        nextFireTime = Time.time + 1f / weaponData.fireRate;

        Fire();

        return true;
    }

    protected abstract void Fire();

    protected void SpawnBullet()
    {
        GameObject bulletObject = bulletPool.Get();

        bulletObject.transform.SetPositionAndRotation(
            firePoint.position,
            firePoint.rotation
        );

        Bullet bullet = bulletObject.GetComponent<Bullet>();

        bullet.Initialize(weaponData, firePoint.forward);
    }
}