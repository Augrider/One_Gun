using System;
using UnityEngine;
using Weapons;

namespace Player
{
    public class PlayerStatsComponent : MonoBehaviour, IPlayerWeaponStatsProvider, IPlayerStatsProvider
    {
        [SerializeField] private PlayerStatsSO defaultStats;
        public WeaponStats Current { get; private set; }

        public int MaxHealth { get; private set; }
        public float MoveSpeedMultiplier { get; private set; }

        public event Action StatsChanged;
        public event Action WeaponStatsChanged;


        private void Awake()
        {
            Current = defaultStats.WeaponStats;

            MaxHealth = defaultStats.MaxHealth;
            MoveSpeedMultiplier = defaultStats.SpeedMultiplier;
        }

        public void Import(WeaponStats weaponStats)
        {
            Current = weaponStats;
            WeaponStatsChanged?.Invoke();
        }

        public void SetMaxHealth(int value)
        {
            MaxHealth = Mathf.Clamp(value, 1, int.MaxValue);
            StatsChanged?.Invoke();
        }

        public void SetMoveSpeedMultiplier(float value)
        {
            MoveSpeedMultiplier = Mathf.Clamp(value, 0.2f, 2);
            StatsChanged?.Invoke();
        }
    }
}