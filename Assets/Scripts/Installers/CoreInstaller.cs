using Game.SceneNavigation;
using Game.ObjectPool;
using PauseControl;
using UI.GameLost;
using UI.Upgrades;
using UI.Victory;
using UnityEngine;
using WaveSpawn;
using Zenject;


public class CoreInstaller : MonoInstaller
{
    [SerializeField] private PrefabPool prefabPool;
    [SerializeField] private GameNavigation gameNavigation;

    [SerializeField] private WaveSpawnController waveSpawnController;
    [SerializeField] private PauseController pauseController;

    [SerializeField] private UI_UpgradeScreen upgradeScreen;
    [SerializeField] private UI_VictoryScreen victoryScreen;
    [SerializeField] private UI_GameLostScreen gameLostScreen;


    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<PrefabPool>().FromInstance(prefabPool).AsSingle();
        Container.BindInterfacesAndSelfTo<GameNavigation>().FromInstance(gameNavigation).AsSingle();

        Container.BindInterfacesAndSelfTo<WaveSpawnController>().FromInstance(waveSpawnController).AsSingle();
        Container.BindInterfacesAndSelfTo<PauseController>().FromInstance(pauseController).AsSingle();

        Container.BindInterfacesAndSelfTo<UI_UpgradeScreen>().FromInstance(upgradeScreen).AsSingle();
        Container.BindInterfacesAndSelfTo<UI_VictoryScreen>().FromInstance(victoryScreen).AsSingle();
        Container.BindInterfacesAndSelfTo<UI_GameLostScreen>().FromInstance(gameLostScreen).AsSingle();
    }
}
