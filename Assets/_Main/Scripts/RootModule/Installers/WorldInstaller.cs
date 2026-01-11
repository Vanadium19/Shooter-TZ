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
        [Header("Cover Peek Settings")]
        [SerializeField] private float peekDistance = 0.4f;
        [SerializeField] private float peekSpeed = 8f;

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
                .WithArguments(peekDistance, peekSpeed)
                .NonLazy();
        }
    }
}
