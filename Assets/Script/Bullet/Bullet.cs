using UnityEngine;

public class Bullet : MonoBehaviour, IPoolable
{
    private Vector3 moveDirection;

    private PoolMember poolMember;
    private WeaponData weaponData;

    private float lifeTimer;

    private void Awake()
    {
        poolMember = GetComponent<PoolMember>();
    }

    public void Initialize(WeaponData data, Vector3 direction)
    {
        weaponData = data;
        moveDirection = direction.normalized;
    }

    public void OnSpawn()
    {
        lifeTimer = 0f;
    }

    public void OnDespawn()
    {
        lifeTimer = 0f;
        weaponData = null;
    }

    private void Update()
    {
        transform.position += moveDirection * weaponData.bulletSpeed * Time.deltaTime;

        lifeTimer += Time.deltaTime;

        if (lifeTimer >= weaponData.bulletLifeTime)
        {
            poolMember.ReturnToPool();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        IDamageable damageable =
            other.GetComponent<IDamageable>();

        if (damageable == null)
        {
            damageable = other.GetComponentInParent<IDamageable>();
        }

        if (damageable != null)
        {
            damageable.TakeDamage(weaponData.damage);
        }

        poolMember.ReturnToPool();
    }
}