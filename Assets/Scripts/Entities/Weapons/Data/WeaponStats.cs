using UnityEngine;

namespace Weapons
{
    [System.Serializable]
    public struct WeaponStats
    {
        [Range(0.3f, 5)]
        [SerializeField] private float reloadSpeedMultiplier;
        [Range(1, 999999)]
        [SerializeField] private int magazineSize;

        [Range(0.2f, float.MaxValue)]
        [SerializeField] private float bulletDamage;
        [Range(1, 50)]
        [SerializeField] private int bulletsPerShot;
        [Range(0, 180)]
        [SerializeField] private float bulletSpread;
        [Range(1, 5000)]
        [SerializeField] private float bulletSpeed;

        [Range(0, 30)]
        [SerializeField] private float baseDeviation;
        [Range(0, 1)]
        [SerializeField] private float shotRecoil;
        [Range(0.5f, 10)]
        [SerializeField] private float recoilControl;

        [Range(0.3f, 1000)]
        [SerializeField] private float rateOfFire;

        [Range(0, int.MaxValue)]
        [SerializeField] private int penetration;

        public float ReloadSpeedMultiplier
        {
            get => reloadSpeedMultiplier;
            set => reloadSpeedMultiplier = Mathf.Clamp(value, 0.3f, 5);
        }
        public int MagazineSize
        {
            get => magazineSize;
            set => magazineSize = Mathf.Clamp(value, 1, int.MaxValue);
        }

        public float BulletDamage
        {
            get => bulletDamage;
            set => bulletDamage = Mathf.Clamp(value, 0.2f, float.MaxValue);
        }
        public int BulletsPerShot
        {
            get => bulletsPerShot;
            set => bulletsPerShot = Mathf.Clamp(value, 1, 50);
        }
        public float BulletSpread
        {
            get => bulletSpread;
            set => bulletSpread = Mathf.Clamp(value, 0, 180);
        }
        public float BulletSpeed
        {
            get => bulletSpeed;
            set => bulletSpeed = Mathf.Clamp(value, 1, 5000);
        }

        public float BaseDeviation
        {
            get => baseDeviation;
            set => baseDeviation = Mathf.Clamp(value, 0, 30);
        }
        public float ShotRecoil
        {
            get => shotRecoil;
            set => shotRecoil = Mathf.Clamp(value, 0, 1);
        }
        public float RecoilControl
        {
            get => recoilControl;
            set => recoilControl = Mathf.Clamp(value, 0.5f, 10);
        }

        public float RateOfFire
        {
            get => rateOfFire;
            set => rateOfFire = Mathf.Clamp(value, 0.3f, 1000);
        }

        public int Penetration
        {
            get => penetration;
            set => penetration = Mathf.Clamp(value, 0, int.MaxValue);
        }


        public WeaponStats Clone(WeaponStats weaponStats)
        {
            var result = new WeaponStats();

            result.reloadSpeedMultiplier = weaponStats.reloadSpeedMultiplier;
            result.magazineSize = weaponStats.magazineSize;

            result.bulletDamage = weaponStats.bulletDamage;
            result.bulletsPerShot = weaponStats.bulletsPerShot;
            result.bulletSpread = weaponStats.bulletSpread;
            result.bulletSpeed = weaponStats.bulletSpeed;

            result.baseDeviation = weaponStats.baseDeviation;
            result.shotRecoil = weaponStats.shotRecoil;
            result.recoilControl = weaponStats.recoilControl;

            result.rateOfFire = weaponStats.rateOfFire;

            result.penetration = weaponStats.penetration;

            return result;
        }
    }
}