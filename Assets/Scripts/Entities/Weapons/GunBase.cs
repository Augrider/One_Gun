using System.Collections;
using UnityEngine;

namespace Weapons
{
    public class GunBase : MonoBehaviour, IPlayerGun
    {
        [SerializeField] private WeaponVisuals visuals;
        [SerializeField] private ProjectileLauncher projectileLauncher;

        private bool shootPressed = false;

        private Coroutine current;
        // private bool isShooting = false;
        // private bool reloading = false;

        private IPlayerWeaponStatsProvider WeaponStatsProvider { get; set; }
        private IADSProvider ADSProvider { get; set; }
        private WeaponStats WeaponStats => WeaponStatsProvider.Current;

        private float FireCooldown => 1 / WeaponStats.RateOfFire;

        public int AmmoInMag { get; private set; }
        public float Recoil { get; private set; }


        public void Initialize(IMainObject player)
        {
            WeaponStatsProvider = player.GetComponent<IPlayerWeaponStatsProvider>();
            ADSProvider = player.GetComponent<IADSProvider>();

            AmmoInMag = WeaponStats.MagazineSize;

            enabled = true;
        }


        void OnDisable()
        {
            StopAllCoroutines();
            current = null;

            shootPressed = false;
        }


        void Update()
        {
            Recoil = Mathf.Clamp(Recoil - WeaponStats.RecoilControl * (1 + ADSProvider.ADSMultiplier) * Time.deltaTime, 0, 1);
        }


        public void ToggleActive(bool value)
        {
            gameObject.SetActive(value);
        }


        public bool TryShooting()
        {
            Debug.Log("Trying to shoot");

            if (current != null)
                return false;

            if (AmmoInMag <= 0)
            {
                visuals.PlayNoAmmo();
                return false;
            }

            shootPressed = true;
            current = StartCoroutine(ShootRoutine(WeaponStats));
            return true;
        }

        public void StopShooting()
        {
            Debug.Log("Stopping shooting");

            shootPressed = false;
        }

        public void SetAiming()
        {
            throw new System.NotImplementedException();
        }

        public void ReleaseAiming()
        {
            throw new System.NotImplementedException();
        }


        public bool TryReload()
        {
            if (AmmoInMag >= WeaponStats.MagazineSize)
                return false;

            if (current != null)
                StopAllCoroutines();

            current = StartCoroutine(ReloadRoutine(WeaponStats));
            return true;
        }



        private IEnumerator ShootRoutine(WeaponStats weaponStats)
        {
            var delay = new WaitForSeconds(FireCooldown);

            while (shootPressed)
            {
                if (AmmoInMag <= 0)
                {
                    visuals.PlayNoAmmo();
                    break;
                }

                var deviation = GetDeviation(Recoil);

                var projectiles = projectileLauncher.Shoot(weaponStats.BulletsPerShot, weaponStats.BulletSpread, deviation);
                visuals.TriggerShot();

                foreach (var projectile in projectiles)
                    projectile.Initialize(weaponStats);

                Recoil = Mathf.Clamp(Recoil + WeaponStats.ShotRecoil, 0, 1);
                AmmoInMag--;

                yield return delay;
            }

            current = null;
        }

        private IEnumerator ReloadRoutine(WeaponStats weaponStats)
        {
            visuals.TriggerReload();

            yield return new WaitForSeconds(1);
            AmmoInMag = WeaponStats.MagazineSize;

            current = null;
        }

        //TODO: Proper deviation
        private Quaternion GetDeviation(float recoil)
        {
            float angleOffset = Random.Range(0, WeaponStats.BaseDeviation * (recoil - ADSProvider.ADSMultiplier * 0.2f));
            float verticalOffset = Random.Range(-20, 20);

            var deviation = Quaternion.Euler(0, 0, verticalOffset) * Quaternion.Euler(-angleOffset, 0, 0);
            return deviation;
        }
    }
}