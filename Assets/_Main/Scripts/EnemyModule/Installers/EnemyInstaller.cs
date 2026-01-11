using ComponentsModule;
using UnityEngine;
using Zenject;

namespace EnemyModule
{
    public class EnemyInstaller : MonoInstaller
    {
        [Header("Health Settings")]
        [SerializeField] private int maxHealth = 5;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<HealthComponent>()
                .AsSingle()
                .WithArguments(maxHealth)
                .NonLazy();
        }
    }
}