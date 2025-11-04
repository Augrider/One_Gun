using System.Collections;
using System.Collections.Generic;
using Game.ObjectPool;
using UnityEngine;
using Zenject;

namespace Weapons
{
    public class ProjectileLauncher : MonoBehaviour
    {
        [Inject] private IObjectPoolHandle objectPool;

        [SerializeField] private GameObject projectilePrefab;


        /// <summary>
        /// Shoot amount of projectiles forward with randomized spread
        /// </summary>
        public IEnumerable<AttackProjectile> Shoot(int amount, float spread)
        {
            return Shoot(amount, spread, Quaternion.identity);
        }

        /// <summary>
        /// Shoot amount of projectiles forward with randomized spread and provided deviation
        /// </summary>
        public IEnumerable<AttackProjectile> Shoot(int amount, float spread, Quaternion deviation)
        {
            List<AttackProjectile> projectileList = new();

            //Spawn X projectiles, deviate them randomly
            for (int i = 0; i < amount; i++)
            {
                // Calculate random spread within spreadAngle
                float angleOffset = Random.Range(0, spread / 2f);
                float verticalOffset = Random.Range(0, 360);
                Quaternion spreadRotation = deviation * Quaternion.Euler(0, 0, verticalOffset) * Quaternion.Euler(0, angleOffset, 0);

                var projectile = SpawnProjectile(spreadRotation);
                projectile.Initialize();

                // Instantiate projectile
                projectileList.Add(projectile);
            }

            return projectileList;
        }


        protected AttackProjectile SpawnProjectile(Quaternion deviation)
        {
            var projectileObject = objectPool.GetNew(projectilePrefab);
            projectileObject.transform.SetPositionAndRotation(transform.position, transform.rotation * deviation);

            return projectileObject.GetComponent<AttackProjectile>();
        }
    }
}