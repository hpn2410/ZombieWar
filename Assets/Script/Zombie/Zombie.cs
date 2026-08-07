using UnityEngine;

public class Zombie : MonoBehaviour, IPoolable
{
    [SerializeField] private ZombieHealth health;
    [SerializeField] private ZombieAI ai;
    [SerializeField] private ZombieAnimationHandle animationHandle;

    public void OnSpawn()
    {
        health.ResetHealth();
        ai.ResetAI();
        animationHandle.ResetAnimation();
    }

    public void OnDespawn()
    {

    }
}