using UnityEngine;
using Upgrades;

namespace UI.Upgrades
{
    public abstract class BaseUpgradeSO : ScriptableObject
    {
        [field: SerializeField] public string Name { get; private set; }


        public abstract IUpgrade GetUpgrade();
        public abstract string GetEffectDescription();
    }
}