using CoreModule;
using EntityModule;
using MainModule;
using PlayerModule;
using UIModule;
using UnityEngine;
using Zenject;

namespace RootModule
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private TimeZone winZone;
        [SerializeField] private Entity player;
        [SerializeField] GameView gameView;

        public override void InstallBindings()
        {
            Container.Bind<PlayerProvider>()
                .AsSingle()
                .WithArguments(player)
                .NonLazy();

            Container.Bind<TimeZone>()
                .FromInstance(winZone)
                .AsSingle();

            Container.BindInterfacesTo<CameraCrouchController>()
                .AsSingle()
                .NonLazy();

            Container.BindInterfacesTo<CameraCoverPeekController>()
                .AsSingle()
                .NonLazy();

            Container.BindInterfacesTo<LevelService>()
                .AsSingle()
                .NonLazy();

            Container.BindInterfacesTo<LevelPresenter>()
                .AsSingle()
                .NonLazy();

            Container.BindInterfacesTo<GameService>()
                .AsSingle()
                .NonLazy();

            Container.BindInterfacesTo<GamePresenter>()
                .AsSingle()
                .NonLazy();

            Container.Bind<GameView>()
                .FromInstance(gameView)
                .AsSingle();

            CoreModuleInstaller.Install(Container);
        }
    }
}