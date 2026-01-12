using UnityEngine;
using VFXModule;
using Zenject;

namespace WeaponModule
{
    public class GunInstaller : MonoInstaller
    {
        [SerializeField] private GunData _gunData;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<Gun>()
                .AsSingle()
                .WithArguments(_gunData)
                .NonLazy();

            Container.BindInterfacesTo<GunPresenter>()
                .AsSingle()
                .NonLazy();
        }
    }
}