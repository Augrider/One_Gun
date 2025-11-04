using System;

namespace Player
{
    public interface IPlayerStatsProvider
    {
        event Action StatsChanged;

        int MaxHealth { get; }
        float MoveSpeedMultiplier { get; }

        void SetMaxHealth(int value);
        void SetMoveSpeedMultiplier(float value);
    }
}