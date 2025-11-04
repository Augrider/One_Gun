using Player;
using UnityEngine;
using Zenject;

namespace Enemies
{
    /// <summary>
    /// Class for enemy behaviors that control enemy actions in game
    /// </summary>
    public abstract class EnemyBehavior : BaseComponent
    {
        [Inject] protected IPlayerStateProvider PlayerState { get; private set; }
    }
}