using UnityEngine;
using UnityEngine.AI;

namespace Enemies
{
    public class Enemy_MoveTowardsPlayer : EnemyBehavior
    {
        [SerializeField] private NavMeshAgent navMeshAgent;

        [SerializeField] private float minDistance;
        [SerializeField] private float maxDistance;


        void OnDisable()
        {
            Stop();
        }

        void Update()
        {
            if (InsideRange())
                navMeshAgent.destination = PlayerState.Position;
            else
                Stop();
        }



        private void Stop()
        {
            navMeshAgent.destination = MainObject.Position;
        }

        private bool InsideRange()
        {
            var sqrDistance = (MainObject.Position - PlayerState.Position).sqrMagnitude;
            return sqrDistance >= minDistance * minDistance && sqrDistance <= maxDistance * maxDistance;
        }
    }
}