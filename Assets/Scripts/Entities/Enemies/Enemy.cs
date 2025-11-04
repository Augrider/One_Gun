using System;
using Game.ObjectPool;
using UnityEngine;
using Weapons;
using Zenject;

namespace Enemies
{
    public class Enemy : CachedObject, IEnemy, IDamageable
    {
        [SerializeField] private BaseEnemyAI enemyAI;
        [SerializeField] private GameObject corpsePrefab;

        [SerializeField] private float maxHealth;
        private float health;


        void OnEnable()
        {
            health = maxHealth;
            enemyAI.enabled = true;
        }

        void OnDisable()
        {
            enemyAI.enabled = false;
        }


        public void ApplyDamage(float value)
        {
            health -= value;

            if (health < 0)
                Die();
        }



        private void Die()
        {
            IEnemy.InvokeDiedEvent(this);
            Instantiate(corpsePrefab, transform.position, transform.rotation);
            Disable();
        }
    }
}