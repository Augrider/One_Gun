using Player;
using UnityEngine;

namespace Pickups
{
    public abstract class PickupBase : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip pickupSound;

        void OnTriggerEnter(Collider other)
        {
            var mainObject = other.gameObject.GetComponentInParent<IMainObject>() ?? throw new System.Exception("Unit without Main Object component!");

            if (TryApply(mainObject))
            {
                audioSource.PlayOneShot(pickupSound);
                Destroy(gameObject);
            }
        }


        protected abstract bool TryApply(IMainObject player);
    }
}