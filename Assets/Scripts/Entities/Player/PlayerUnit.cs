using System;
using UnityEngine;
using Weapons;

namespace Player
{
    public class PlayerUnit : MainObject, IPlayerStateProvider
    {
        public event Action HealthChanged;
        public event Action AmmoInMagChanged;

        [SerializeField] private PlayerHealthComponent playerHealthComponent;
        [SerializeField] private GunBase playerGun;

        public int Health { get; private set; }
        public int AmmoInMag { get; private set; }


        void Start()
        {
            Health = playerHealthComponent.Health;
            AmmoInMag = playerGun.AmmoInMag;
        }

        void LateUpdate()
        {
            if (playerHealthComponent.Health != Health)
            {
                Health = playerHealthComponent.Health;
                HealthChanged?.Invoke();
            }

            if (playerGun.AmmoInMag != AmmoInMag)
            {
                AmmoInMag = playerGun.AmmoInMag;
                AmmoInMagChanged?.Invoke();
            }
        }
    }
}