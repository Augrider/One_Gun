using UnityEngine;

public class MainObject : MonoBehaviour, IMainObject
{
    public Vector3 Position => transform.position;
    Transform IMainObject.Transform => transform;


    T IMainObject.GetComponent<T>()
    {
        var component = GetComponentInChildren<T>();

        if (component is null)
            throw new System.Exception($"Component {typeof(T)} was not found on main or any child objects");

        return component;
    }

    bool IMainObject.TryGetComponent<T>(out T component)
    {
        component = GetComponentInChildren<T>();
        return component != null;
    }
}
