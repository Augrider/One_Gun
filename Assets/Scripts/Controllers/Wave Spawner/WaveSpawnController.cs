using System;
using Game.ObjectPool;
using UnityEngine;
using Upgrades;
using Zenject;

namespace WaveSpawn
{
    public class WaveSpawnController : MonoBehaviour, IWavesState
    {
        [Inject] private IObjectPoolHandle objectPool;

        [SerializeField] private UpgradesController upgradesController;
        [SerializeField] private ScoreBasedDifficulty difficulty;
        [SerializeField] private Transform[] spawnPoints;

        public int Wave { get; private set; }
        public int EnemiesLeft => throw new NotImplementedException();


        public void SpawnNewWave()
        {
            //Start spawning wave
            //find next type of spawn
            //find random spawn point
            //spawn and wait a little
        }



        private void OnEnemyCountChanged()
        {
            if (EnemiesLeft > 0)
                return;

            //If all waves completed - victory
            //Start upgrade selection after delay
        }
    }
}