using Zenject;

namespace CoreModule
{
    public class CoreModuleInstaller : Installer<CoreModuleInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<PauseService>()
                .AsSingle()
                .NonLazy();

            Container.BindInterfacesTo<GameService>()
                .AsSingle()
                .NonLazy();

            Container.BindInterfacesTo<GamePresenter>()
                .AsSingle()
                .NonLazy();
        }
    }
}