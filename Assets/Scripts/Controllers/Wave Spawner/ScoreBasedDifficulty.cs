using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WaveSpawn
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Game Difficulty/Score Based")]
    public class ScoreBasedDifficulty : ScriptableObject
    {
        [SerializeField] private GameObject defaultSpawnObject;
        [SerializeField] private SpawnData[] secondarySpawns;

        [SerializeField] protected int startingPoints;
        [SerializeField] protected int wavePoints;


        public GameObject[] GetWaveSpawns(int currentWave)
        {
            var totalPoints = startingPoints + wavePoints * (currentWave - 1);

            var entityList = new List<GameObject>();

            foreach (var spawn in secondarySpawns)
            {
                if (spawn.minimalWave > currentWave)
                    continue;

                var amount = GetEntitiesAmount(totalPoints, spawn.spawnCost, spawn.maxAmount);

                for (int j = 0; j < amount; j++)
                    entityList.Add(spawn.entityObject);

                totalPoints -= spawn.spawnCost * amount;
            }

            for (int j = 0; j < totalPoints; j++)
                entityList.Add(defaultSpawnObject);

            return entityList.ToArray();
        }


        /// <summary>
        /// Calculate the amount of units for spawn
        /// </summary>
        /// <param name="totalPoints">Current points left</param>
        /// <param name="spawnCost">Amount of points for one spawn</param>
        /// <param name="maxAmount">Max amount of spawns</param>
        private int GetEntitiesAmount(int totalPoints, int spawnCost, int maxAmount)
        {
            var amount = totalPoints / spawnCost;

            if (maxAmount > 0)
                amount = Mathf.Min(amount, maxAmount);

            return Random.Range(0, amount);
        }



        [System.Serializable]
        private struct SpawnData
        {
            public GameObject entityObject;

            public int spawnCost;
            public int minimalWave;
            public int maxAmount;
        }
    }
}