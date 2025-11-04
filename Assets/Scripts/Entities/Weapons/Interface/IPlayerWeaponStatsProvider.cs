using System;
using UnityEngine;

namespace Weapons
{
    public interface IPlayerWeaponStatsProvider
    {
        event Action WeaponStatsChanged;

        //TODO: Add separate default stats, delta, methods for changing (maybe in separate interface)
        WeaponStats Current { get; }

        /// <summary>
        /// Import all stats from provided
        /// </summary>
        void Import(WeaponStats weaponStats);
    }
}