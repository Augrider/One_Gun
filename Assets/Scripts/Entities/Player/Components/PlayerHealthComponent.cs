using System;
using System.Collections;
using UnityEngine;
using Weapons;

namespace Player
{
    public class PlayerHealthComponent : BaseComponent, IDamageable
    {
        [SerializeField] private float immunityTime;

        private IPlayerStatsProvider playerStatsProvider;

        private bool immune = false;
        public int Health { get; private set; }
        public int MaxHealth => playerStatsProvider.MaxHealth;



        protected override void Awake()
        {
            base.Awake();

            playerStatsProvider = MainObject.GetComponent<IPlayerStatsProvider>();
        }

        void Start()
        {
            Health = MaxHealth;
        }


        void OnDisable()
        {
            StopAllCoroutines();
            immune = false;
        }


        public void ApplyDamage(float damage)
        {
            if (immune)
                return;

            Health--;
            if (Health <= 0)
                return;

            StartCoroutine(ImmunityRoutine());
        }

        public void Heal(int value)
        {
            if (Health >= MaxHealth)
                return;

            Health = Mathf.Clamp(Health + value, 0, MaxHealth);
        }



        private IEnumerator ImmunityRoutine()
        {
            immune = true;

            yield return new WaitForSeconds(immunityTime);

            immune = false;
        }
    }
}