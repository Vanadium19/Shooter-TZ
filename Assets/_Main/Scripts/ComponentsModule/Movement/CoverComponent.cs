using UnityEngine;

namespace ComponentsModule
{
    public class CoverComponent : ICoverComponent
    {
        private readonly Transform _origin;
        private readonly Rigidbody _rigidbody;
        private readonly float _checkDistance;
        private readonly float _coverOffset;
        private readonly float _maxDetachDistance;
        private readonly LayerMask _coverMask;

        public CoverComponent(Transform origin, Rigidbody rigidbody, float checkDistance, float coverOffset,
            float maxDetachDistance, LayerMask coverMask)
        {
            _origin = origin;
            _rigidbody = rigidbody;
            _checkDistance = checkDistance;
            _coverOffset = coverOffset;
            _maxDetachDistance = maxDetachDistance;
            _coverMask = coverMask;
        }

        public bool IsInCover { get; private set; }
        public Vector3 CoverNormal { get; private set; }
        private Vector3 CoverPoint { get; set; }

        public bool TryEnterCover()
        {
            if (IsInCover)
                return true;

            if (!Physics.Raycast(_origin.position, _origin.forward, out var hit, _checkDistance, _coverMask))
                return false;

            CoverNormal = hit.normal;
            CoverPoint = hit.point;
            IsInCover = true;

            var targetPosition = hit.point + hit.normal * _coverOffset;
            targetPosition.y = _rigidbody.position.y;
            _rigidbody.position = targetPosition;

            return true;
        }

        public void ExitCover()
        {
            if (!IsInCover)
                return;

            IsInCover = false;
        }

        public void UpdateCoverState()
        {
            if (!IsInCover)
                return;

            var delta = _rigidbody.position - CoverPoint;
            delta.y = 0f;

            if (delta.sqrMagnitude <= _maxDetachDistance * _maxDetachDistance)
                return;

            ExitCover();
        }
    }
}
