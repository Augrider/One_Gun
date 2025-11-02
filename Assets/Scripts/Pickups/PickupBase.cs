using Player;
using UnityEngine;

namespace Pickups
{
    public abstract class PickupBase : MonoBehaviour
    {
        [SerializeField] private AudioClip pickupSound;

        void OnTriggerEnter(Collider other)
        {
            // var player = other.gameObject.GetComponentInParent<PlayerCharacter>();
            // // If found player character component - add something
            // if (!player)
            //     throw new System.Exception("Player without PlayerCharacter component!");

            // if (TryApply(player))
            // {
            //     GlobalAudioSource.Instance.PlaySound(pickupSound);
            //     Destroy(gameObject);
            // }
        }


        // protected abstract bool TryApply(PlayerCharacter player);
    }
}