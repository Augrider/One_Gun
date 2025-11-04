using UnityEngine;
using WaveSpawn;
using Zenject;

namespace Upgrades
{
    public class UpgradesController : MonoBehaviour
    {
        [Inject] private IUpgradeSelectUI upgradeSelectUI;
        [Inject] private IMainObject player;

        [SerializeField] private WaveSpawnController waveSpawnController;


        public void StartUpgradeSelection()
        {
            upgradeSelectUI.UpgradeSelected += OnUpgradeSelected;
            upgradeSelectUI.StartUpgradeSelection();
        }



        private void OnUpgradeSelected(IUpgrade upgrade)
        {
            if (upgrade != null)
                upgrade.Apply(player);

            waveSpawnController.SpawnNewWave();
        }
    }
}