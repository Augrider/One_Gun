using PauseControl;
using Player;
using TMPro;
using UnityEngine;
using WaveSpawn;
using Zenject;

namespace UI.GameLost
{
    public class UI_GameLostScreen : MonoBehaviour
    {
        [Inject] private PauseController pauseController;
        [Inject] private IWavesState wavesState;
        [Inject] private IPlayerStateProvider playerState;

        [SerializeField] private Canvas gameLostCanvas;

        [SerializeField] private TextMeshProUGUI textEndMessage;
        [SerializeField, Multiline] private string endMessageText;


        void Start()
        {
            gameLostCanvas.enabled = false;
        }

        void LateUpdate()
        {
            if (playerState.Health <= 0)
                TriggerGameLoss();
        }


        public void TriggerGameLoss()
        {
            textEndMessage.SetText(endMessageText, wavesState.Wave);

            gameLostCanvas.enabled = true;
            pauseController.TogglePause(true);
        }
    }
}