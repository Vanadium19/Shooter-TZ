using System;
using ComponentsModule;
using EntityModule;
using UnityEngine;

namespace WeaponModule
{
    public class Gun : IWeapon
    {
        private readonly Transform _firePoint;
        private readonly float _distance;
        private readonly int _layerMask;

        private readonly float _delay;
        private readonly int _damage;

        private float _lastTime;

        public event Action<Transform> Used;
        public event Action<Vector3, Vector3> Hit;

        public Gun(Transform firePoint, float distance, LayerMask layerMask, int damage, float delay)
        {
            _firePoint = firePoint;
            _distance = distance;
            _layerMask = layerMask;
            _damage = damage;
            _delay = delay;
        }

        public bool IsReady => _lastTime + _delay < Time.time;

        public void Use()
        {
            if (!IsReady)
                return;

            _lastTime = Time.time;
            Used?.Invoke(_firePoint);

            if (!Physics.Raycast(_firePoint.position, _firePoint.forward, out var hitInfo, _distance, _layerMask))
                return;

            if (!hitInfo.collider.TryGetComponent<IEntity>(out var entity))
                return;

            if (!entity.TryGet<IHealthComponent>(out var health))
                return;

            Hit?.Invoke(hitInfo.point, hitInfo.normal);
            health.ApplyDamage(_damage);
        }
    }
}