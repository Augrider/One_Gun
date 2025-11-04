using UnityEngine;
using Weapons;

namespace Player
{
    public class PlayerWeaponsComponent : BaseComponent, IPlayerWeaponsInput
    {
        [SerializeField] private GunBase gun;
        [SerializeField] private PlayerWeaponHandleComponent weaponHandle;


        void Start()
        {
            gun.Initialize(MainObject);
        }


        public void SetPrimaryPressed()
        {
            if (!gun.TryShooting())
                return;
        }

        public void SetPrimaryReleased()
        {
            // gun.OnPrimaryReleased();
            gun.StopShooting();
        }


        public void SetSecondaryPressed()
        {
            weaponHandle.SetAiming();
        }

        public void SetSecondaryReleased()
        {
            weaponHandle.ReleaseAiming();
        }


        public void SetReloadPressed()
        {
            gun.TryReload();
        }
    }
}