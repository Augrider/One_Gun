using Player;
using UnityEngine;
using WaveSpawn;
using Zenject;

namespace Upgrades
{
    public class UpgradesController : MonoBehaviour
    {
        [Inject] private IUpgradeSelectUI upgradeSelectUI;
        [Inject] private IMainObject player;

        [Inject] private IPlayerStateProvider playerState;
        [Inject] private IPlayerStatsProvider playerStats;

        [SerializeField] private WaveSpawnController waveSpawnController;
        [SerializeField] private float waveSpawnDelay;
        [SerializeField] private float moveSpeedMultiplierAdd;


        void Start()
        {
            StartUpgradeSelection();
        }

        public void StartUpgradeSelection()
        {
            upgradeSelectUI.UpgradeSelected += OnUpgradeSelected;

            Invoke(nameof(UIStartSelection), waveSpawnDelay);
        }



        private void OnUpgradeSelected(IUpgrade upgrade)
        {
            if (upgrade != null)
                upgrade.Apply(player);

            Debug.Log($"Selected {upgrade}");

            //TODO: Add game rules and move heal there
            playerStats.SetMoveSpeedMultiplier(playerStats.MoveSpeedMultiplier + moveSpeedMultiplierAdd);
            player.GetComponent<PlayerHealthComponent>().Heal(playerStats.MaxHealth);

            upgradeSelectUI.UpgradeSelected -= OnUpgradeSelected;

            Invoke(nameof(SpawnNewWave), waveSpawnDelay);
        }

        private void UIStartSelection() => upgradeSelectUI.StartUpgradeSelection();
        private void SpawnNewWave() => waveSpawnController.SpawnNewWave();
    }
}