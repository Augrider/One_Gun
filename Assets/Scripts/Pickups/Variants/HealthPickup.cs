using Player;
using UnityEngine;

namespace Pickups
{
    public class HealthPickup : PickupBase
    {
        [SerializeField] private int healValue;


        // protected override bool TryApply(PlayerCharacter player)
        // {
        //     var healthComponent = player.GetComponent<PlayerHealthComponent>();

        //     if (healthComponent.Health >= healthComponent.MaxHealth)
        //         return false;

        //     healthComponent.Heal(healValue);
        //     return true;
        // }
    }
}