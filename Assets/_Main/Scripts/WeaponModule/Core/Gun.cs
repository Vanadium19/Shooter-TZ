using System;
using ComponentsModule;
using EntityModule;
using UnityEngine;

namespace WeaponModule
{
    public class Gun : IWeapon
    {
        private readonly GunData _data;

        private float _lastFireTime;

        private float _reloadEndTime;
        private bool _isReloading;
        private int _currentAmmo;

        public event Action<Transform> Used;
        public event Action<Vector3, Vector3> Hit;

        public Gun(GunData data)
        {
            _data = data;
            _currentAmmo = _data.MagazineSize;
        }

        public void Use()
        {
            if (_isReloading && Time.time >= _reloadEndTime)
                EndReload();
            
            if (_isReloading)
                return;

            if (_lastFireTime + _data.ShootDelay > Time.time)
                return;

            Shoot();

            if (_currentAmmo <= 0)
                Reload();
        }

        private void Shoot()
        {
            _lastFireTime = Time.time;
            _currentAmmo--;

            var firePoint = _data.FirePoint;
            Used?.Invoke(firePoint);

            if (!Physics.Raycast(firePoint.position, firePoint.forward, out var hitInfo, _data.Distance, _data.LayerMask))
                return;

            if (!hitInfo.collider.TryGetComponent<IEntity>(out var entity))
                return;

            if (!entity.TryGet<IHealthComponent>(out var health))
                return;

            Hit?.Invoke(hitInfo.point, hitInfo.normal);
            health.ApplyDamage(_data.Damage);
        }

        private void Reload()
        {
            _isReloading = true;
            _reloadEndTime = Time.time + _data.ReloadingTime;
        }

        private void EndReload()
        {
            _isReloading = false;
            _currentAmmo = _data.MagazineSize;
        }
    }
}