using UnityEngine;

public class PlayerBomb : MonoBehaviour
{
    [SerializeField] private ObjectPool bombPool;
    [SerializeField] private ObjectPool bombVFXPool;
    [SerializeField] private Transform bombSpawnPoint;
    [SerializeField] private float bombCooldown = 2f;

    private float nextBombTime;

    public void PlaceBomb()
    {
        if (Time.time < nextBombTime)
            return;

        nextBombTime = Time.time + bombCooldown;

        GameObject bombObject = bombPool.Get();

        bombObject.transform.position = bombSpawnPoint.position;
        bombObject.transform.rotation = Quaternion.identity;

        Bomb bomb = bombObject.GetComponent<Bomb>();
        bomb.SetVFXPool(bombVFXPool);
    }
}