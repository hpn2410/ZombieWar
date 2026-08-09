using UnityEngine;

public class SpawnZombieManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private ObjectPool zombiePool;
    [SerializeField] private Transform player;

    [Header("Spawn Settings")]
    [SerializeField] private float spawnInterval = 5f;
    [SerializeField] private float spawnRadius = 12f;

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnZombie();
        }
    }

    private void SpawnZombie()
    {
        Zombie zombie = zombiePool.Get<Zombie>();

        Vector2 random = Random.insideUnitCircle.normalized * spawnRadius;

        Vector3 spawnPos = player.position + new Vector3(random.x, 0f, random.y);

        zombie.transform.SetPositionAndRotation(spawnPos, Quaternion.identity);
    }
}