using UnityEngine;

namespace Weapons
{
    public class MachineGun : GunBase
    {
        [Tooltip("Spread angle in degrees for machine gun bullet spread")]
        [SerializeField] private float spreadAngle = 2f;

        [SerializeField] private AudioClip reloadSound;

        protected override void ShootOnce()
        {
            float angleOffset = Random.Range(-spreadAngle / 2f, spreadAngle / 2f);

            Quaternion spreadRotation = Quaternion.Euler(0, angleOffset, 0);

            var projectile = SpawnProjectile();

            projectile.transform.rotation *= spreadRotation;
        }

        private void PlayReloadSound()
        {
            // audioSource.PlaySound(reloadSound, 0.2f);
        }
    }
}