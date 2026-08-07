using UnityEngine;

public class PoolMember : MonoBehaviour
{
    private ObjectPool ownerPool;

    public void SetPool(ObjectPool pool)
    {
        ownerPool = pool;
    }

    public void ReturnToPool()
    {
        if (ownerPool != null)
        {
            ownerPool.Return(gameObject);
        }
    }
}