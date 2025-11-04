using System;
using Game.ObjectPool;
using UnityEngine;

namespace Weapons
{
    [RequireComponent(typeof(Rigidbody))]
    public class AttackProjectile : CachedObject
    {
        [SerializeField] private TrailRenderer trailRenderer;

        [SerializeField] private float damage;
        [SerializeField] private float speed;

        [SerializeField] private int penetration;

        [SerializeField] private float lifetime = 3f;

        private Rigidbody rb;


        void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        void OnDisable()
        {
            trailRenderer.enabled = false;
            trailRenderer.Clear();
        }


        void OnTriggerEnter(Collider other)
        {
            var mainObject = other.GetComponentInParent<IMainObject>();

            if (mainObject != null)
            {
                if (mainObject.TryGetComponent<IDamageable>(out var damageable))
                    damageable.ApplyDamage(damage);

                if (penetration-- < 0)
                    Disable();

                return;
            }

            Disable();
        }


        public void Initialize()
        {
            trailRenderer.enabled = true;
            trailRenderer.Clear();

            rb.velocity = speed * transform.forward;
            Disable(lifetime);

            trailRenderer.enabled = true;
            trailRenderer.Clear();
        }

        public void Initialize(WeaponStats weaponStats)
        {
            damage = weaponStats.BulletDamage;
            speed = weaponStats.BulletSpeed;
            penetration = weaponStats.Penetration;

            rb.velocity = speed * transform.forward;
        }
    }
}