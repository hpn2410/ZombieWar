using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int initialSize = 20;

    private Queue<GameObject> pool = new();

    private void Awake()
    {
        for (int i = 0; i < initialSize; i++)
        {
            CreateObject();
        }
    }

    private GameObject CreateObject()
    {
        GameObject obj = Instantiate(prefab, transform);

        obj.SetActive(false);

        PoolMember member = obj.GetComponent<PoolMember>();

        if (member == null)
        {
            Debug.LogError($"{prefab.name} is missing PoolMember component!");
            return obj;
        }

        member.SetPool(this);

        pool.Enqueue(obj);

        return obj;
    }

    public GameObject Get()
    {
        if (pool.Count == 0)
            CreateObject();

        GameObject obj = pool.Dequeue();

        obj.SetActive(true);

        if (obj.TryGetComponent(out IPoolable poolable))
            poolable.OnSpawn();

        return obj;
    }

    public T Get<T>() where T : Component
    {
        return Get().GetComponent<T>();
    }

    public void Return(GameObject obj)
    {
        if (obj.TryGetComponent(out IPoolable poolable))
            poolable.OnDespawn();

        obj.SetActive(false);

        pool.Enqueue(obj);
    }
}