using PauseControl;
using UnityEngine;
using WaveSpawn;
using Zenject;

namespace UI.Victory
{
    public class UI_VictoryScreen : MonoBehaviour, IVictoryUI
    {
        [Inject] private PauseController pauseController;

        [SerializeField] private Canvas victoryCanvas;


        void Start()
        {
            victoryCanvas.enabled = false;
        }

        public void TriggerVictory()
        {
            victoryCanvas.enabled = true;
            pauseController.TogglePause(true);
        }
    }
}