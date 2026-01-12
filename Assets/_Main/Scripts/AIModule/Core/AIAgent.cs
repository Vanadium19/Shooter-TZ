using AIModule.States;
using CoreModule;
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
        private IPauseService _pauseService;

        private void OnEnable() => _stateMachine?.OnEnter();

        private void Start() => CreateAI();

        private void Update()
        {
            if (_pauseService.IsPaused)
                return;

            _stateMachine.OnUpdate(Time.deltaTime);
        }

        private void OnDisable() => _stateMachine.OnExit();

        private void OnDestroy()
        {
            _stateMachine.OnExit();
            _pauseService.Paused -= OnPaused;
            _pauseService.Resumed -= OnResumed;
        }

        [Inject]
        public void Construct(IPauseService pauseService)
        {
            _pauseService = pauseService;
            _pauseService.Paused += OnPaused;
            _pauseService.Resumed += OnResumed;
        }

        private void CreateAI()
        {
            _stateMachine = (IStateMachine<StateName>)stateMachineAsset.Create(context);
            _stateMachine.OnEnter();
        }

        private void OnPaused() => _stateMachine?.OnExit();

        private void OnResumed() => _stateMachine?.OnEnter();
    }
}