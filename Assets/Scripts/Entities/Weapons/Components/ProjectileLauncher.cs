using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapons
{
    public class ProjectileLauncher : MonoBehaviour
    {
        [SerializeField] private GameObject projectilePrefab;


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

                // Instantiate projectile
                projectileList.Add(SpawnProjectile(spreadRotation));
            }

            return projectileList;
        }


        protected AttackProjectile SpawnProjectile(Quaternion deviation)
        {
            var projectileObject = Instantiate(projectilePrefab, transform.position, transform.rotation * deviation);
            return projectileObject.GetComponent<AttackProjectile>();
        }
    }
}