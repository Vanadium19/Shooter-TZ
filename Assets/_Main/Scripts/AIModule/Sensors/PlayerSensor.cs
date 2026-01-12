using System;
using CoreModule;
using EntityModule;
using PlayerModule;
using UnityEngine;
using Zenject;

namespace AIModule
{
    public class PlayerSensor : MonoBehaviour
    {
        [SerializeField] private float viewAngle = 90f;
        [SerializeField] private float viewDistance = 12f;
        [SerializeField] private LayerMask obstacleMask;

        private Blackboard _blackboard;
        private IGameService _gameService;

        private void OnDestroy()
        {
            _gameService.Restarted -= DeleteTarget;
        }

        private void OnTriggerStay(Collider other)
        {
            if (!other.TryGetComponent(out IEntity entity))
                return;

            if (!entity.TryGet(out PlayerTag playerTag))
                return;

            var target = entity.Get<Transform>();

            if (!IsInSight(target, other))
                return;

            _blackboard.SetObject(BlackboardTag.Target, target);
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.TryGetComponent(out IEntity entity))
                return;

            if (!entity.TryGet(out PlayerTag playerTag))
                return;

            DeleteTarget();
        }

        [Inject]
        public void Construct(IGameService gameService, Blackboard blackboard)
        {
            _blackboard = blackboard;
            _gameService = gameService;
            _gameService.Restarted += DeleteTarget;
        }

        private bool IsInSight(Transform target, Collider targetCollider)
        {
            var direction = target.position - transform.position;
            var distance = direction.magnitude;

            if (distance > viewDistance)
                return false;

            var angle = Vector3.Angle(transform.forward, direction);

            if (angle > viewAngle * 0.5f)
                return false;

            if (Physics.Raycast(transform.position, direction.normalized, out var hit, distance, obstacleMask))
                return hit.collider == targetCollider;

            return true;
        }

        private void DeleteTarget()
        {
            _blackboard.DeleteObject(BlackboardTag.Target);
        }
    }
}