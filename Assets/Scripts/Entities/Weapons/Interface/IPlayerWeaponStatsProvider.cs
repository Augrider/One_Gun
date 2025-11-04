using System;
using UnityEngine;

namespace Weapons
{
    public interface IPlayerWeaponStatsProvider
    {
        event Action WeaponStatsChanged;

        //TODO: Add separate default stats, delta, methods for changing (maybe in separate interface)
        WeaponStats Current { get; }

        void Import(WeaponStats weaponStats);
    }
}