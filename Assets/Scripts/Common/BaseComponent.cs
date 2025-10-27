using UnityEngine;

/// <summary>
/// Type of Mono Behaviour that is attached as part of entity
/// </summary>
public class BaseComponent : MonoBehaviour
{
    protected IMainObject MainObject { get; private set; }


    protected virtual void Awake()
    {
        MainObject = GetComponentInParent<IMainObject>();

        if (MainObject is null)
            throw new System.Exception($"{this} was not able to find main object!");
    }
}
