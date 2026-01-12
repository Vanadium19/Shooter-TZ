using FSMModule;
using UnityEngine;
using UnityEngine.AI;

namespace AIModule.States
{
    public class PatrolState : IState
    {
        private readonly Blackboard _blackboard;

        private readonly Transform[] _points;
        private readonly float _lappingDistance;

        private Transform _transform;
        private NavMeshAgent _agent;

        private int _currentPointIndex;

        public PatrolState(Blackboard blackboard, Transform[] points, float lappingDistance)
        {
            _blackboard = blackboard;
            _points = points;
            _lappingDistance = lappingDistance;
        }

        public void OnEnter()
        {
            _agent ??= _blackboard.GetObject<NavMeshAgent>(BlackboardTag.NavMeshAgent);
            _transform ??= _blackboard.GetObject<Transform>(BlackboardTag.Transform);
            _agent.destination = _points[_currentPointIndex].position;
        }

        public void OnUpdate(float deltaTime)
        {
            if (Vector3.Distance(_transform.position, _points[_currentPointIndex].position) > _lappingDistance)
                return;

            _currentPointIndex++;
            _currentPointIndex %= _points.Length;
            _agent.destination = _points[_currentPointIndex].position;
        }

        public void OnExit()
        {
            if (!_agent.isActiveAndEnabled)
                return;

            _agent.isStopped = true;
        }
    }
}