using UnityEngine;
using VFXModule;
using Zenject;

namespace WeaponModule
{
    public class GunInstaller : MonoInstaller
    {
        [SerializeField] private Transform _firePoint;
        [SerializeField] private float _distance = 100f;
        [SerializeField] private LayerMask _layerMask;

        [SerializeField] private int _damage = 10;
        [SerializeField] private float _delay = 0.5f;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<Gun>()
                .AsSingle()
                .WithArguments(_firePoint, _distance, _layerMask, _damage, _delay)
                .NonLazy();

            Container.BindInterfacesTo<GunPresenter>()
                .AsSingle()
                .NonLazy();
        }
    }
}