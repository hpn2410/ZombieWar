using UnityEngine;

public class BombVFX : MonoBehaviour, IPoolable
{
    private ParticleSystem particle;
    private PoolMember poolMember;

    private void Awake()
    {
        particle = GetComponent<ParticleSystem>();
        poolMember = GetComponent<PoolMember>();
    }

    public void OnSpawn()
    {
        particle.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);

        particle.Play();
    }

    public void OnDespawn()
    {
        particle.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
    }

    private void Update()
    {
        if (!particle.IsAlive())
        {
            poolMember.ReturnToPool();
        }
    }
}