using UnityEngine;

public class PoolTether : MonoBehaviour
{
    GameObjectPool posessionPool;

    public void AssignPool(GameObjectPool pool)
    {
        posessionPool = pool;
    }

    public void ReturnToPool()
    {
        posessionPool.ReturnObject(gameObject);
    }
}
