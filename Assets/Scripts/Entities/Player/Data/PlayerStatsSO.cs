using UnityEngine;
using Weapons;

namespace Player
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Player/Stats")]
    public class PlayerStatsSO : ScriptableObject
    {
        [Range(1, 10)]
        [SerializeField] private int maxHealth;
        [Range(0.2f, 2)]
        [SerializeField] private float speedMultiplier;

        [SerializeField] private WeaponStats weaponStats;

        public int MaxHealth => maxHealth;
        public float SpeedMultiplier => speedMultiplier;

        public WeaponStats WeaponStats => weaponStats;
    }
}