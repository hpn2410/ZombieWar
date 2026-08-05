using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected float fireRate = 5f;

    private float nextFireTime;

    public abstract void SetFireAnimation(bool active);

    public void TryFire()
    {
        if (Time.time < nextFireTime)
            return;

        nextFireTime = Time.time + 1f / fireRate;

        Fire();
    }

    protected abstract void Fire();
}
