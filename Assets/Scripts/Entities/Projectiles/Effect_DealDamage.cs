using UnityEngine;

namespace Weapons
{
    public class Effect_DealDamage : MonoBehaviour
    {
        [SerializeField] private int damage;

        public AudioSource hitAudioSource; // Assign in inspector
        public ParticleSystem hitParticleSystem; // Assign in inspector

        private Rigidbody rb;
        private MeshRenderer meshRenderer;
        private Collider colliderComponent;

        public float hitDisableDuration = 0.5f; // How long to disable after hit

        void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<IDamageable>(out var damageable))
                damageable.DealDamage(damage);

            DestroyBullet();
        }

        void Start()
        {
            rb = GetComponent<Rigidbody>();

            meshRenderer = GetComponent<MeshRenderer>();
            colliderComponent = GetComponent<Collider>();
        }

        private void DestroyBullet()
        {
            if (hitAudioSource != null)
            {
                hitAudioSource.Play();
            }

            if (hitParticleSystem != null)
            {
                hitParticleSystem.Play();
            }

            if (meshRenderer != null)
                meshRenderer.enabled = false;

            if (colliderComponent != null)
                colliderComponent.enabled = false;


            Invoke(nameof(DestroySelf), hitDisableDuration);
        }

        private void DestroySelf()
        {
            Destroy(gameObject);
        }
    }




    public interface IDamageable
    {
        void DealDamage(float value);
    }
}