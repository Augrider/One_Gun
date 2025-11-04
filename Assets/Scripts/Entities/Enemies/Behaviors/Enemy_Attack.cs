using System;
using System.Collections;
using UnityEngine;
using Weapons;
using Zenject;

namespace Enemies
{
    public class Enemy_Attack : EnemyBehavior
    {
        [SerializeField] private float minDistance;
        [SerializeField] private float maxDistance;

        [SerializeField] private ProjectileLauncher projectileLauncher;

        [SerializeField] private float spread;
        [SerializeField] private int projectileCount;
        [SerializeField] private float rateOfFire;
        [SerializeField] private bool turnLauncherToPlayer;

        private bool isShooting = false;


        void OnDisable()
        {
            StopAllCoroutines();
            isShooting = false;
        }

        void Update()
        {
            if (InsideRange())
                ShootAtPlayer();
            else
                StopShooting();

            if (turnLauncherToPlayer)
                projectileLauncher.transform.forward = (PlayerState.Position - MainObject.Position).normalized;
        }



        private void ShootAtPlayer()
        {
            if (isShooting)
                return;

            StartCoroutine(ShootRoutine());
        }

        private void StopShooting()
        {
            isShooting = false;
        }


        private bool InsideRange()
        {
            var sqrDistance = (MainObject.Position - PlayerState.Position).sqrMagnitude;
            return sqrDistance >= minDistance * minDistance && sqrDistance <= maxDistance * maxDistance;
        }


        private IEnumerator ShootRoutine()
        {
            isShooting = true;

            while (enabled && isShooting)
            {
                projectileLauncher.Shoot(projectileCount, spread);

                yield return new WaitForSeconds(1 / rateOfFire);
            }

            isShooting = false;
        }
    }
}