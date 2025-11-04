using System;
using UnityEngine;

namespace Enemies
{
    public interface IEnemy
    {
        /// <summary>
        /// Event called when enemy died
        /// </summary>
        /// Note: IEnemy in event simplifies identification
        static event Action<IEnemy> Died;
        static void InvokeDiedEvent(IEnemy enemy) => Died?.Invoke(enemy);
    }
}