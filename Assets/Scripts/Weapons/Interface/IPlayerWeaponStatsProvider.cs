using UnityEngine;

namespace Weapons
{
    public interface IPlayerWeaponStatsProvider
    {
        //TODO: Add separate default stats, delta, methods for changing (maybe in separate interface)
        WeaponStats WeaponStats { get; }
    }
}