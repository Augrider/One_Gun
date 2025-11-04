using TMPro;
using UnityEngine;
using WaveSpawn;
using Zenject;

namespace UI.HUD
{
    public class UI_GameState : MonoBehaviour
    {
        [Inject] private IWavesState wavesState;

        [SerializeField] private TextMeshProUGUI textWave;
        [SerializeField] private TextMeshProUGUI textEnemiesLeft;


        void Update()
        {
            Refresh();
        }



        private void Refresh()
        {
            if (wavesState == null)
                return;

            textWave.SetText($"{wavesState.Wave}");
            textEnemiesLeft.SetText($"{wavesState.EnemiesLeft}");
        }
    }
}