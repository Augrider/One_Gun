using System;
using UnityEngine;

namespace Player
{
    public interface IPlayerStateProvider
    {
        event Action HealthChanged;
        event Action AmmoInMagChanged;

        Vector3 Position { get; }

        int Health { get; }
        int AmmoInMag { get; }

        //TODO: Import/Export
        //TODO: UniRx integration, change to reactive values
    }
}