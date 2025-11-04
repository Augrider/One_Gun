using UnityEngine;
using Weapons;

namespace Upgrades
{
    //TODO: Rework upgrade system, add separate classes for each stat, add percentage changes
    [System.Serializable]
    public class Upgrade_Weapon : IUpgrade
    {
        [SerializeField] private float reloadSpeedMultiplierDelta;
        [SerializeField] private int magazineSizeDelta;

        [SerializeField] private float bulletDamageDelta;
        [SerializeField] private int bulletsPerShotDelta;
        [SerializeField] private float bulletSpreadDelta;
        [SerializeField] private float bulletSpeedDelta;

        [SerializeField] private float baseDeviationDelta;
        [SerializeField] private float shotRecoilDelta;
        [SerializeField] private float recoilControlDelta;

        [SerializeField] private float rateOfFireDelta;

        [SerializeField] private int penetrationDelta;


        public Upgrade_Weapon Clone()
        {
            var result = new Upgrade_Weapon();

            result.reloadSpeedMultiplierDelta = reloadSpeedMultiplierDelta;
            result.magazineSizeDelta = magazineSizeDelta;

            result.bulletDamageDelta = bulletDamageDelta;
            result.bulletsPerShotDelta = bulletsPerShotDelta;
            result.bulletSpreadDelta = bulletSpreadDelta;
            result.bulletSpeedDelta = bulletSpeedDelta;

            result.baseDeviationDelta = baseDeviationDelta;
            result.shotRecoilDelta = shotRecoilDelta;
            result.recoilControlDelta = recoilControlDelta;

            result.rateOfFireDelta = rateOfFireDelta;

            result.penetrationDelta = penetrationDelta;

            return result;
        }


        public void Apply(IMainObject player)
        {
            var weaponStatsProvider = player.GetComponent<IPlayerWeaponStatsProvider>();
            var weaponStats = weaponStatsProvider.Current;

            weaponStats.ReloadSpeedMultiplier += reloadSpeedMultiplierDelta;
            weaponStats.MagazineSize += magazineSizeDelta;

            weaponStats.BulletDamage += bulletDamageDelta;
            weaponStats.BulletsPerShot += bulletsPerShotDelta;
            weaponStats.BulletSpread += bulletSpreadDelta;
            weaponStats.BulletSpeed += bulletSpeedDelta;

            weaponStats.BaseDeviation += baseDeviationDelta;
            weaponStats.ShotRecoil += shotRecoilDelta;
            weaponStats.RecoilControl += recoilControlDelta;

            weaponStats.RateOfFire += rateOfFireDelta;

            weaponStats.Penetration += penetrationDelta;

            weaponStatsProvider.Import(weaponStats);
        }

        public string GetEffectDescription()
        {
            var result = string.Empty;

            if (reloadSpeedMultiplierDelta != 0)
                result += "Reload Speed Multiplier " + reloadSpeedMultiplierDelta.ToString() + "\n";
            if (magazineSizeDelta != 0)
                result += "Magazine Size " + magazineSizeDelta.ToString() + "\n";

            if (bulletDamageDelta != 0)
                result += "Damage " + bulletDamageDelta.ToString() + "\n";
            if (bulletSpeedDelta != 0)
                result += "Bullet Speed " + bulletSpeedDelta.ToString() + "\n";
            if (bulletsPerShotDelta != 0)
                result += "Bullet Count " + bulletsPerShotDelta.ToString() + "\n";
            if (bulletSpreadDelta != 0)
                result += "Spread " + bulletSpreadDelta.ToString() + "\n";

            if (baseDeviationDelta != 0)
                result += "Deviation " + baseDeviationDelta.ToString() + "\n";
            if (shotRecoilDelta != 0)
                result += "Recoil " + shotRecoilDelta.ToString() + "\n";
            if (recoilControlDelta != 0)
                result += "Recoil Control " + recoilControlDelta.ToString() + "\n";

            if (rateOfFireDelta != 0)
                result += "Rate Of Fire " + rateOfFireDelta.ToString() + "\n";

            if (penetrationDelta != 0)
                result += "Penetration " + penetrationDelta.ToString() + "\n";

            return result;
        }
    }
}