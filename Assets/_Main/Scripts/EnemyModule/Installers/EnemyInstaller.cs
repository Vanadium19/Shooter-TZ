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

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<HealthComponent>()
                .AsSingle()
                .WithArguments(maxHealth)
                .NonLazy();

            Container.BindInterfacesTo<AttackComponent>()
                .AsSingle();

            Container.Bind<Blackboard>()
                .FromMethod(CreateBlackboard)
                .AsSingle();
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