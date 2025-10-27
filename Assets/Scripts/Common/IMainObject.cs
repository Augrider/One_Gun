using UnityEngine;

/// <summary>
/// Interface for component placed on main game object of entity
/// </summary>
public interface IMainObject
{
    Vector3 Position { get; }

    T GetComponent<T>();
    bool TryGetComponent<T>(out T component);
}