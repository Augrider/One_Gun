using System.Collections;
using UnityEngine;

namespace Weapons
{
    public class GunBase : MonoBehaviour
    {
        private const string SHOOT_TRIGGER_NAME = "Shoot";

        [SerializeField] private Animator animator;
        [SerializeField] protected AudioSource audioSource;

        [Tooltip("Transform where projectiles will spawn")]
        [SerializeField] public Transform gunPoint;

        [Tooltip("Projectile prefab to spawn")]
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private AudioClip shotSound;

        [Header("Weapon parameters")]
        [Tooltip("Amount of shots per second")]
        [SerializeField] private float rateOfFire = 0.5f;

        private bool isShooting = false;
        private Coroutine shootRoutine;

        private float FireCooldown => 1 / rateOfFire;


        void OnDisable()
        {
            StopAllCoroutines();
            isShooting = false;
        }


        public void ToggleActive(bool value)
        {
            gameObject.SetActive(value);
        }


        /// <summary>
        /// Attempts to shoot a projectile if cooldown allows.
        /// Call this method from input or other scripts.
        /// </summary>
        /// <returns>True if shot was fired, false if still cooling down</returns>
        public bool Shoot()
        {
            if (isShooting)
                return false;

            shootRoutine = StartCoroutine(ShootRoutine());
            return true;
        }


        private IEnumerator ShootRoutine()
        {
            isShooting = true;

            ShootOnce();

            if (animator)
                animator.Play(SHOOT_TRIGGER_NAME);

            // audioSource.PlaySound(shotSound, 0.2f);

            yield return new WaitForSeconds(FireCooldown);

            isShooting = false;
        }

        protected virtual void ShootOnce()
        {
            SpawnProjectile();
        }


        protected AttackProjectile SpawnProjectile()
        {
            GameObject projectileObject = Instantiate(projectilePrefab, gunPoint.position, gunPoint.rotation);
            return projectileObject.GetComponent<AttackProjectile>();
        }
    }
}