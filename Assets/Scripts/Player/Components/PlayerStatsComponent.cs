using UnityEngine;
using Weapons;

namespace Player
{
    public class PlayerStatsComponent : MonoBehaviour, IPlayerWeaponStatsProvider
    {
        [field: SerializeField] private WeaponStats weaponStats;
        public WeaponStats WeaponStats => weaponStats;
    }
}