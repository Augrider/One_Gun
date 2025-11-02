namespace Weapons
{
    [System.Serializable]
    public struct WeaponStats
    {
        public float ReloadSpeedMultiplier;
        public int MagazineSize;

        public float BulletDamage;
        public int BulletsPerShot;
        public float BulletSpread;
        public float BulletSpeed;

        public float BaseDeviation;
        public float ShotRecoil;
        public float RecoilControl;

        public float RateOfFire;

        public int Penetration;
    }
}