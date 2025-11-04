using System;
using TMPro;
using UnityEngine;

namespace UI.Upgrades
{
    public class UI_UpgradeCard : MonoBehaviour
    {
        public static event Action<BaseUpgradeSO> UpgradeSelected;

        private BaseUpgradeSO upgradeSO;

        [SerializeField] private TextMeshProUGUI textName;
        [SerializeField] private TextMeshProUGUI textDescription;


        public void SetUpgradeSO(BaseUpgradeSO upgradeSO)
        {
            this.upgradeSO = upgradeSO;

            textName.SetText(upgradeSO.Name);
            textDescription.SetText(upgradeSO.GetEffectDescription());
        }


        public void CallSelected()
        {
            if (upgradeSO is null)
                throw new Exception("Button pressed, but upgrade is empty");

            UpgradeSelected?.Invoke(upgradeSO);
        }
    }
}