using AIModule;
using ComponentsModule;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace EnemyModule
{
    public class EnemyInstaller : MonoInstaller
    {
        [Header("References")]
        [SerializeField] private Transform enemy;
        [SerializeField] private NavMeshAgent agent;

        [Header("Health Settings")]
        [SerializeField] private int maxHealth = 5;

        [Header("Rotation Settings")]
        [SerializeField] private float rotationSpeed = 5f;

        public override void InstallBindings()
        {
            Container.Bind<Transform>()
                .FromInstance(enemy)
                .AsSingle();

            Container.BindInterfacesTo<HealthComponent>()
                .AsSingle()
                .WithArguments(maxHealth)
                .NonLazy();

            Container.BindInterfacesTo<TargetRotationComponent>()
                .AsSingle()
                .WithArguments(rotationSpeed)
                .NonLazy();

            Container.BindInterfacesTo<AttackComponent>()
                .AsSingle();

            Container.Bind<Blackboard>()
                .FromMethod(CreateBlackboard)
                .AsSingle();

            Container.BindInterfacesTo<EnemyLifeCycleController>()
                .AsSingle()
                .NonLazy();
        }

        private Blackboard CreateBlackboard()
        {
            var blackboard = new Blackboard();
            blackboard.SetObject(BlackboardTag.Transform, enemy);
            blackboard.SetObject(BlackboardTag.NavMeshAgent, agent);
            return blackboard;
        }
    }
}