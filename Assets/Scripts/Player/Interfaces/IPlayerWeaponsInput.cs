namespace Player
{
    /// <summary>
    /// Interface for player weapon input
    /// </summary>
    public interface IPlayerWeaponsInput
    {
        void SetPrimaryPressed();
        void SetPrimaryReleased();

        void SetSecondaryPressed();
        void SetSecondaryReleased();

        //Switch weapon input
    }
}