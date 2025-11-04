using UnityEngine;

namespace Upgrades
{
    public interface IUpgrade
    {
        void Apply(IMainObject player);
        string GetEffectDescription();
    }
}