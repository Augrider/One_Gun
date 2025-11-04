using UnityEngine;

namespace Enemies
{
    /// <summary>
    /// Simple container with behaviors, no decision making
    /// </summary>
    public class BaseEnemyAI : MonoBehaviour
    {
        [SerializeField] private EnemyBehavior[] enemyBehaviors;


        void OnEnable()
        {
            foreach (var behavior in enemyBehaviors)
                behavior.enabled = true;
        }

        void OnDisable()
        {
            foreach (var behavior in enemyBehaviors)
                behavior.enabled = false;
        }
    }
}