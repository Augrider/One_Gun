using UnityEngine;

namespace Player
{
    /// <summary>
    /// Interface for player camera input
    /// </summary>
    public interface IPlayerCameraInput
    {
        void SetCameraInput(Vector2 value);
    }
}