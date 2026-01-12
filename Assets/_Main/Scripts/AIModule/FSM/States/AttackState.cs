using ComponentsModule;
using FSMModule;
using UnityEngine;
using UnityEngine.AI;

namespace AIModule.States
{
    public class AttackState : IState
    {
        private readonly Blackboard _blackboard;
        private readonly IAttackComponent _attacker;
        private readonly float _stoppingDistance;

        private NavMeshAgent _agent;

        public AttackState(Blackboard blackboard, IAttackComponent attacker, float stoppingDistance)
        {
            _blackboard = blackboard;
            _attacker = attacker;
            _stoppingDistance = stoppingDistance;
        }

        public void OnEnter()
        {
            _agent ??= _blackboard.GetObject<NavMeshAgent>(BlackboardTag.NavMeshAgent);
            _agent.isStopped = false;
        }

        public void OnUpdate(float deltaTime)
        {
            if (!_blackboard.TryGetObject<Transform>(BlackboardTag.Target, out var target))
                return;

            if (Vector3.Distance(_agent.transform.position, target.position) <= _stoppingDistance)
                _agent.isStopped = true;
            else
                SetDestination(target);

            _attacker.Attack();
        }

        public void OnExit()
        {
            if (!_agent.isActiveAndEnabled)
                return;

            _agent.isStopped = true;
        }

        private void SetDestination(Transform target)
        {
            _agent.isStopped = false;
            _agent.SetDestination(target.position);
        }
    }
}