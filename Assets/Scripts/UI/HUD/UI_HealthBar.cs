using System.Collections;
using Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.HUD
{
    public class UI_HealthBar : MonoBehaviour
    {
        [Inject] private IPlayerStateProvider playerState;
        [Inject] private IPlayerStatsProvider playerStats;

        [SerializeField] private Slider healthSlider;
        [SerializeField] private TextMeshProUGUI textHealth;


        IEnumerator Start()
        {
            yield return null;

            Refresh();
        }

        void OnEnable()
        {
            playerState.HealthChanged += Refresh;
            playerStats.StatsChanged += Refresh;

            Refresh();
        }

        void OnDisable()
        {
            playerState.HealthChanged -= Refresh;
            playerStats.StatsChanged -= Refresh;
        }



        private void Refresh()
        {
            if (playerState == null || playerStats == null)
                return;

            healthSlider.maxValue = playerStats.MaxHealth;
            healthSlider.SetValueWithoutNotify(playerState.Health);

            textHealth.SetText($"{playerState.Health}/{playerStats.MaxHealth}");
        }
    }
}