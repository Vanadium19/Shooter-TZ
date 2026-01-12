using AIModule.States;
using FSMModule;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace AIModule
{
    public class AIAgent : MonoBehaviour
    {
        [SerializeField] private GameObjectContext context;

        [SerializeField] private Transform enemy;
        [SerializeField] private NavMeshAgent agent;

        [SerializeField] private AutoStateMachineAsset stateMachineAsset;

        private IStateMachine<StateName> _stateMachine;

        private void OnEnable() => _stateMachine?.OnEnter();

        private void Start() => CreateAI();

        private void Update() => _stateMachine.OnUpdate(Time.deltaTime);

        private void OnDisable() => _stateMachine.OnExit();

        private void OnDestroy() => _stateMachine.OnExit();

        private void CreateAI()
        {
            _stateMachine = (IStateMachine<StateName>)stateMachineAsset.Create(context);
            _stateMachine.OnEnter();
        }
    }
}