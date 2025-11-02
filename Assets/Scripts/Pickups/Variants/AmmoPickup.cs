using Player;
using UnityEngine;
using Weapons;

namespace Pickups
{
    public class AmmoPickup : PickupBase
    {
        [SerializeField] private int ammoValue;


        // protected override bool TryApply(PlayerCharacter player)
        // {
        //     // var healthComponent = player.GetComponent<PlayerHealthComponent>();

        //     PlayerCharacter.Ammo.ChangeValue(ammoType, ammoValue);
        //     return true;
        // }
    }
}