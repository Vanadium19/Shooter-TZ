using UnityEngine;
using Zenject;

namespace WeaponModule
{
    public class GunInstaller : MonoInstaller
    {
        [SerializeField] private Transform _firePoint;
        [SerializeField] private float _distance = 100f;
        [SerializeField] private LayerMask _layerMask;
        
        [SerializeField] private int _damage = 10;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<Gun>()
                .AsSingle()
                .WithArguments(_firePoint, _distance, _layerMask, _damage)
                .NonLazy();
        }
    }
}