using UnityEngine;
using Upgrades;

namespace UI.Upgrades
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Upgrades/Weapon Upgrade")]
    public class WeaponUpgradeSO : BaseUpgradeSO
    {
        [SerializeField] private Upgrade_Weapon upgrade;


        public override IUpgrade GetUpgrade()
        {
            return upgrade.Clone();
        }

        public override string GetEffectDescription()
        {
            return upgrade.GetEffectDescription();
        }
    }
}