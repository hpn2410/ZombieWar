using UnityEngine;

public class Zombie : MonoBehaviour, IPoolable
{
    [SerializeField] private ZombieHealth health;
    [SerializeField] private ZombieAI ai;
    [SerializeField] private ZombieAnimationHandle animationHandle;
    private PoolMember poolMember;

    private void Awake()
    {
        poolMember = GetComponent<PoolMember>();
    }

    public void OnSpawn()
    {
        health.ResetHealth();
        ai.ResetAI();
        animationHandle.ResetAnimation();
    }

    public void OnDespawn()
    {

    }

    public void ReturnToPool()
    {
        poolMember.ReturnToPool();
    }
}