using Player;
using UnityEngine;
using Zenject;

namespace PauseControl
{
    public class PauseController : MonoBehaviour
    {
        [Inject] private IPlayerInput playerInput;


        public void TogglePause(bool value)
        {
            playerInput.ToggleActive(!value);
        }
    }
}