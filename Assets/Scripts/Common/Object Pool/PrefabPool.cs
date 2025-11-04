using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Game.ObjectPool
{
    public class PrefabPool : MonoBehaviour, IObjectPoolHandle
    {
        private Dictionary<int, List<GameObject>> objectCache = new Dictionary<int, List<GameObject>>();

        [Inject] private DiContainer Container { get; set; }


        public T GetNew<T>(GameObject prefab)
        {
            if (!objectCache.ContainsKey(prefab.GetInstanceID()))
                return Create<T>(prefab);

            Debug.LogWarning($"Search {objectCache[prefab.GetInstanceID()][0]}");
            var disabledObject = objectCache[prefab.GetInstanceID()].FirstOrDefault(t => !t.activeInHierarchy);

            if (disabledObject == null)
                return Create<T>(prefab);

            disabledObject.SetActive(true);
            return disabledObject.GetComponent<T>();
            //if found disabled object - return GetComponent
            //Else create new
        }

        public GameObject GetNew(GameObject prefab)
        {
            if (!objectCache.ContainsKey(prefab.GetInstanceID()))
                return Create(prefab);

            var disabledObject = objectCache[prefab.GetInstanceID()].FirstOrDefault(t => !t.activeInHierarchy);

            if (disabledObject == null)
                return Create(prefab);

            disabledObject.SetActive(true);
            return disabledObject;
            //if found disabled object - return GetComponent
            //Else create new
        }



        private GameObject Create(GameObject prefab)
        {
            var created = Container.InstantiatePrefab(prefab);
            AddToRegistry(prefab.GetInstanceID(), created);

            return created;
        }

        private T Create<T>(GameObject prefab)
        {
            var created = Create(prefab);
            return created.GetComponent<T>();
        }


        private void AddToRegistry(int prefabID, GameObject created)
        {
            if (!objectCache.ContainsKey(prefabID))
                objectCache.Add(prefabID, new List<GameObject>());

            objectCache[prefabID].Add(created);
        }
    }
}