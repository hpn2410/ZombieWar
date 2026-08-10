using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour, IPoolable
{
    [SerializeField] private float explodeDelay = 1.5f;
    [SerializeField] private float explosionRadius = 5f;
    [SerializeField] private int damage = 30;
    [SerializeField] private LayerMask damageLayer;

    private PoolMember poolMember;
    private ObjectPool bombVFXPool;

    private void Awake()
    {
        poolMember = GetComponent<PoolMember>();
    }

    public void SetVFXPool(ObjectPool pool)
    {
        bombVFXPool = pool;
    }

    public void OnSpawn()
    {
        CancelInvoke();

        Invoke(nameof(Explode), explodeDelay);
    }

    public void OnDespawn()
    {
        CancelInvoke();
    }

    private void Explode()
    {
        DealDamage();
        PlayBombVFX();
        MusicManager.Instance.PlaySound(MusicManager.Instance.BombExplose);

        poolMember.ReturnToPool();
    }

    private void DealDamage()
    {
        Collider[] hitColliders = Physics.OverlapSphere(
            transform.position,
            explosionRadius,
            damageLayer
        );

        HashSet<IDamageable> targets = new();

        foreach (Collider collider in hitColliders)
        {
            IDamageable damageable =
                collider.GetComponentInParent<IDamageable>();

            if (damageable != null)
            {
                targets.Add(damageable);
            }
        }

        foreach (IDamageable target in targets)
        {
            target.TakeDamage(damage);
        }
    }

    private void PlayBombVFX()
    {
        if (bombVFXPool == null)
        {
            return;
        }

        GameObject vfx = bombVFXPool.Get();
        vfx.transform.position = transform.position;
        vfx.transform.rotation = Quaternion.identity;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(
            transform.position,
            explosionRadius
        );
    }
}