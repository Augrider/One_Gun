using System;

namespace Upgrades
{
    public interface IUpgradeSelectUI
    {
        event Action<IUpgrade> UpgradeSelected;

        void StartUpgradeSelection();
    }
}