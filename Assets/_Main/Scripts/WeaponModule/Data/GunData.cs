using System;
using UnityEngine;

namespace WeaponModule
{
    [Serializable]
    public class GunData
    {
        [SerializeField] private Transform _firePoint;
        [SerializeField] private float _distance = 100;
        [SerializeField] private LayerMask _layerMask;

        [SerializeField] private float _reloadingTime = 4;
        [SerializeField] private int _magazineSize = 3;

        [SerializeField] private float _shootDelay = 0.5f;
        [SerializeField] private int _damage = 1;

        public Transform FirePoint => _firePoint;
        public float Distance => _distance;
        public int LayerMask => _layerMask;
        public float ReloadingTime => _reloadingTime;
        public int MagazineSize => _magazineSize;
        public float ShootDelay => _shootDelay;
        public int Damage => _damage;
    }
}