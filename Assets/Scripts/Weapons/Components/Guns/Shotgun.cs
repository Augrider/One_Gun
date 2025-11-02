using UnityEngine;

namespace Weapons
{
    public class Shotgun : GunBase
    {
        [Header("Shotgun Settings")]
        [Tooltip("Number of pellets per shot")]
        public int pelletCount = 8;

        [Tooltip("Spread angle in degrees")]
        public float spreadAngle = 10f;

        [SerializeField] private AudioClip reloadSound;
        [SerializeField] private ParticleSystem ps;


        protected override void ShootOnce()
        {
            for (int i = 0; i < pelletCount; i++)
            {
                // Calculate random spread within spreadAngle
                float angleOffset = Random.Range(-spreadAngle / 2f, spreadAngle / 2f);
                float verticalOffset = Random.Range(0, 360);
                Quaternion spreadRotation = Quaternion.Euler(0, 0, verticalOffset) * Quaternion.Euler(0, angleOffset, 0);

                // Instantiate projectile
                var projectile = SpawnProjectile();
                projectile.transform.rotation *= spreadRotation;
            }
        }


        private void PlayReloadSound()
        {
            // audioSource.PlaySound(reloadSound, 0.2f);
        }

        private void PlayShotParticles()
        {
            ps.Play();
        }
    }
}