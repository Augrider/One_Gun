using UnityEngine;

namespace Player
{
    /// <summary>
    /// Interface for player movement input
    /// </summary>
    public interface IPlayerMovementInput
    {
        Vector2 MovementInput { get; }

        void SetMovementInput(Vector2 value);

        void SetJumpPressed();
        void SetJumpReleased();

        // Other things like sprint
    }
}