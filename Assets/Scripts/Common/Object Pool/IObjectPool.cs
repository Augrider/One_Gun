using UnityEngine;

namespace Game.ObjectPool
{
    public interface IObjectPoolHandle
    {
        T GetNew<T>(GameObject prefab);
        GameObject GetNew(GameObject prefab);
    }
}