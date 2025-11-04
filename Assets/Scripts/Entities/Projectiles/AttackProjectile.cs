using UnityEngine;

namespace Weapons
{
    [RequireComponent(typeof(Rigidbody))]
    public class AttackProjectile : MonoBehaviour
    {
        private float damage;
        private float speed;

        private int penetration;

        private float lifetime = 3f;        // Max lifetime before disabling

        private Rigidbody rb;


        void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }


        void OnTriggerEnter(Collider other)
        {
            var mainObject = other.GetComponentInParent<IMainObject>();

            if (mainObject != null)
            {
                if (mainObject.TryGetComponent<IDamageable>(out var damageable))
                    damageable.DealDamage(damage);

                if (penetration-- < 0)
                    Destroy(gameObject);

                return;
            }

            Destroy(gameObject);
        }


        public void Initialize(WeaponStats weaponStats)
        {
            damage = weaponStats.BulletDamage;
            speed = weaponStats.BulletSpeed;
            penetration = weaponStats.Penetration;

            rb.linearVelocity = speed * transform.forward;

            Destroy(gameObject, lifetime);
        }
    }
}