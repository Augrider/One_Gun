using System.Collections;
using System.Collections.Generic;
using Enemies;
using Game.ObjectPool;
using UnityEngine;
using Upgrades;
using Zenject;

namespace WaveSpawn
{
    public class WaveSpawnController : MonoBehaviour, IWavesState
    {
        [Inject] private IObjectPoolHandle objectPool;
        [Inject] private IVictoryUI victoryUI;

        [SerializeField] private UpgradesController upgradesController;
        [SerializeField] private ScoreBasedDifficultySO difficulty;
        [SerializeField] private Transform[] spawnPoints;
        [SerializeField] private float spawnDelay;

        private List<IEnemy> enemiesAlive = new();
        private int spawnCount = 0;

        public int Wave { get; private set; } = 1;
        public int EnemiesLeft => enemiesAlive.Count;


        void Awake()
        {
            IEnemy.Died += OnEnemyDied;
        }

        void OnDestroy()
        {
            IEnemy.Died -= OnEnemyDied;
        }


        public void SpawnNewWave()
        {
            var enemiesToSpawn = difficulty.GetWaveSpawns(Wave);
            spawnCount = enemiesToSpawn.Length;

            Debug.Log($"Starting new wave");

            StartCoroutine(SpawnRoutine(enemiesToSpawn));
        }



        private void OnEnemyDied(IEnemy enemy)
        {
            enemiesAlive.Remove(enemy);

            if (EnemiesLeft > 0 || spawnCount > 0)
                return;

            if (Wave >= difficulty.MaxWaves)
                victoryUI.TriggerVictory();

            Wave++;
            upgradesController.StartUpgradeSelection();
        }


        private IEnumerator SpawnRoutine(GameObject[] enemiesToSpawn)
        {
            var delay = new WaitForSeconds(spawnDelay);

            foreach (var spawn in enemiesToSpawn)
            {
                var spawnerIndex = Random.Range(0, spawnPoints.Length);
                var spawner = spawnPoints[spawnerIndex];

                var enemyObject = objectPool.GetNew<IMainObject>(spawn);
                enemyObject.Transform.SetPositionAndRotation(spawner.position, spawner.rotation);

                var enemy = enemyObject.GetComponent<IEnemy>();
                enemiesAlive.Add(enemy);

                spawnCount--;

                yield return delay;
            }
        }
    }
}