using UnityEngine;

namespace WaveSpawn
{
    public interface IWavesState
    {
        int Wave { get; }
        int EnemiesLeft { get; }
    }
}