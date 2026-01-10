using System.Buffers;
using UnityEngine;

namespace ComponentsModule
{
    public class GroundChecker : IGroundChecker
    {
        private const int ColliderBufferSize = 2;

        private readonly Transform _jumpPoint;
        private readonly float _overlapRadius;
        private readonly int _groundMask;

        public GroundChecker(Transform jumpPoint, float overlapRadius, LayerMask groundMask)
        {
            _jumpPoint = jumpPoint;
            _overlapRadius = overlapRadius;
            _groundMask = groundMask;
        }

        public bool IsGrounded => CheckGround();

        private bool CheckGround()
        {
            var arrayPool = ArrayPool<Collider>.Shared;
            var colliders = arrayPool.Rent(ColliderBufferSize);

            var size = Physics.OverlapSphereNonAlloc(_jumpPoint.position, _overlapRadius, colliders, _groundMask);
            var result = size > 1;

            arrayPool.Return(colliders);
            return result;
        }
    }
}