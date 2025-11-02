using UnityEngine;
using Weapons;

namespace Player
{
    public class PlayerWeaponsComponent : BaseComponent, IPlayerWeaponsInput
    {
        /// <summary>
        /// All guns in game, added to player object
        /// </summary>
        [SerializeField] private GunBase1 gun;


        void Start()
        {
            gun.Initialize(MainObject);
        }

        void Update()
        {
            // if (weaponStats.)
            //Keep shooting if auto fire and pressed

            // if (Input.GetKeyDown(KeyCode.Mouse0) && (Ammo.GetValue(Current.AmmoType) <= 0))
            // {
            //     audioSource.PlaySound(noAmmoSound);
            // }

            // if (Input.GetKey(KeyCode.Mouse0))
            // {
            //     Shoot();
            //     return;
            // }

            // if (Input.mouseScrollDelta.y != 0)
            //     Switch(GetNext(Mathf.RoundToInt(Input.mouseScrollDelta.y)));
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
            //Aim down sights
            gun.SetAiming();
        }

        public void SetSecondaryReleased()
        {
            gun.ReleaseAiming();
        }


        public void SetReloadPressed()
        {
            gun.TryReload();
        }
    }
}