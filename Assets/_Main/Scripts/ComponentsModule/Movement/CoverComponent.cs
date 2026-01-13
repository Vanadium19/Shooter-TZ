using System.Buffers;
using UnityEngine;
using Zenject;

namespace ComponentsModule
{
    public class CoverComponent : ICoverComponent, IFixedTickable
    {
        private const int ColliderBufferSize = 2;

        private readonly Transform _point;
        private readonly float _radius;
        private readonly int _mask;

        private readonly float _peekDistance;

        private bool _isCoverNearby;

        public CoverComponent(Transform point, float radius, LayerMask mask, float peekDistance)
        {
            _point = point;
            _radius = radius;
            _mask = mask;
            _peekDistance = peekDistance;
        }

        public float PeekDistance => _peekDistance;
        public bool IsCoverNearby => _isCoverNearby;

        public void FixedTick() => UpdateCoverState();

        private void UpdateCoverState()
        {
            var arrayPool = ArrayPool<Collider>.Shared;
            var colliders = arrayPool.Rent(ColliderBufferSize);

            var size = Physics.OverlapSphereNonAlloc(_point.position, _radius, colliders, _mask);
            _isCoverNearby = size > 0;

            arrayPool.Return(colliders);
        }
    }
}