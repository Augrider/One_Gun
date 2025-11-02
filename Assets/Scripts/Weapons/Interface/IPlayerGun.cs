namespace Weapons
{
    /// <summary>
    /// Interface for all player guns
    /// </summary>
    public interface IPlayerGun
    {
        //Events for shooting actual bullets, reloading
        int MagAmmo { get; }
        float Recoil { get; }
        float ADSMultiplier { get; }

        void Initialize(IMainObject player);

        /// <summary>
        /// Attempt to start shooting process
        /// Call this method from input or other scripts.
        /// </summary>
        /// <returns>True if able to start shooting process</returns>
        bool TryShooting();
        /// <summary>
        /// Notify gun that player wants to stop shooting
        /// </summary>
        void StopShooting();

        //TODO: If needed - remove from gun and place into separate component
        void SetAiming();
        void ReleaseAiming();

        /// <summary>
        /// Attempt to start reloading process
        /// </summary>
        /// <returns>True if able to start reloading</returns>
        bool TryReload();
    }
}