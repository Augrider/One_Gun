using Player;
using TMPro;
using UnityEngine;
using Weapons;
using Zenject;

namespace UI.HUD
{
    public class UI_AmmoCounter : MonoBehaviour
    {
        [Inject] private IPlayerStateProvider playerState;
        [Inject] private IPlayerWeaponStatsProvider weaponStats;

        [SerializeField] private TextMeshProUGUI textAmmoInMag;
        [SerializeField] private TextMeshProUGUI textMagSize;


        void OnEnable()
        {
            playerState.AmmoInMagChanged += Refresh;
            weaponStats.WeaponStatsChanged += Refresh;

            Refresh();
        }

        void OnDisable()
        {
            playerState.AmmoInMagChanged -= Refresh;
            weaponStats.WeaponStatsChanged -= Refresh;
        }



        private void Refresh()
        {
            if (playerState == null || weaponStats == null)
                return;

            textAmmoInMag.SetText($"{playerState.AmmoInMag}");
            textMagSize.SetText($"{weaponStats.Current.MagazineSize}");
        }
    }
}