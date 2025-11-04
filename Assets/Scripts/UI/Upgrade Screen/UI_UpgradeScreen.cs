using PauseControl;
using UnityEngine;
using Upgrades;
using Zenject;

namespace UI.Upgrades
{
    public class UI_UpgradeScreen : MonoBehaviour, IUpgradeSelectUI
    {
        public event System.Action<IUpgrade> UpgradeSelected;

        [Inject] private PauseController pauseController;

        [SerializeField] private Canvas upgradeScreenCanvas;

        [SerializeField] private UI_UpgradeCard[] upgradeCards;
        [SerializeField] private BaseUpgradeSO[] upgrades;


        void Awake()
        {
            UI_UpgradeCard.UpgradeSelected += OnUpgradeSelected;
            upgradeScreenCanvas.enabled = false;
        }

        void OnDestroy()
        {
            UI_UpgradeCard.UpgradeSelected -= OnUpgradeSelected;
        }


        public void StartUpgradeSelection()
        {
            for (int i = 0; i < upgradeCards.Length; i++)
            {
                var upgradeIndex = Random.Range(0, upgrades.Length);
                upgradeCards[i].SetUpgradeSO(upgrades[upgradeIndex]);
            }

            upgradeScreenCanvas.enabled = true;
            pauseController.TogglePause(true);
        }

        private void OnUpgradeSelected(BaseUpgradeSO upgrade)
        {
            UpgradeSelected?.Invoke(upgrade.GetUpgrade());

            upgradeScreenCanvas.enabled = false;
            pauseController.TogglePause(false);
        }
    }
}