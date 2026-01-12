using EntityModule;
using MainModule;
using PlayerModule;
using UnityEngine;
using Zenject;

namespace RootModule
{
    public class WorldInstaller : MonoInstaller
    {
        [SerializeField] private Entity player;

        public override void InstallBindings()
        {
            Container.Bind<PlayerProvider>()
                .AsSingle()
                .WithArguments(player)
                .NonLazy();

            Container.BindInterfacesTo<CameraCrouchController>()
                .AsSingle()
                .NonLazy();

            Container.BindInterfacesTo<CameraCoverPeekController>()
                .AsSingle()
                .NonLazy();
        }
    }
}