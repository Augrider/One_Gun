using UnityEngine;

namespace Game.ObjectPool
{
    public class CachedObject : MainObject
    {
        /// <summary>
        /// Turn object off, making it free to reuse by object pool
        /// </summary>
        public void Disable() => gameObject.SetActive(false);

        /// <summary>
        /// Turn object off after provided time passed, making it free to reuse by object pool
        /// </summary>
        public void Disable(float lifetime)
        {
            Invoke(nameof(Disable), lifetime);
        }
    }
}