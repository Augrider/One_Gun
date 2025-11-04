using Player;
using UnityEngine;
using Weapons;

namespace Pickups
{
    public class HealthPickup : PickupBase
    {
        protected override bool TryApply(IMainObject player)
        {
            var healthComponent = player.GetComponent<PlayerHealthComponent>();

            if (healthComponent.Health >= healthComponent.MaxHealth)
                return false;

            healthComponent.Heal(1);
            return true;
        }
    }
}