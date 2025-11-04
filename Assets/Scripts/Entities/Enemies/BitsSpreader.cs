using UnityEngine;

namespace Enemies
{
    public class BitsSpreader : MonoBehaviour
    {
        [SerializeField] private Rigidbody[] objectsToLaunch;
        [SerializeField] private Transform blastPoint;

        [SerializeField] private float launchForce = 10f;

        [SerializeField] private float minLifetime = 5f;
        [SerializeField] private float maxLifetime = 7f;


        void Start()
        {
            LaunchObjects();
        }


        public void LaunchObjects()
        {
            foreach (Rigidbody body in objectsToLaunch)
            {
                var force = Random.Range(launchForce * 0.7f, launchForce * 1.3f);
                var lifetime = Random.Range(minLifetime, maxLifetime);

                body.AddExplosionForce(force, blastPoint.position + Random.insideUnitSphere * 0.2f, 10);
                Destroy(body.gameObject, lifetime);
            }

            Destroy(gameObject, maxLifetime);
        }
    }
}