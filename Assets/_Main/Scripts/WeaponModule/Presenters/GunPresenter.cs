using System;
using ComponentsModule;
using UnityEngine;
using VFXModule;
using Zenject;

namespace WeaponModule
{
    public class GunPresenter : IInitializable, IDisposable
    {
        private readonly IWeapon _weapon;
        private readonly IEffectsService _effectsService;

        public GunPresenter(IWeapon weapon, IEffectsService effectsService)
        {
            _weapon = weapon;
            _effectsService = effectsService;
        }

        public void Initialize()
        {
            _weapon.Used += OnUsed;
            _weapon.Hit += OnHit;
        }

        public void Dispose()
        {
            _weapon.Used -= OnUsed;
            _weapon.Hit -= OnHit;
        }

        private void OnUsed(Transform point) => _effectsService.Fire(EffectId.Shoot, point.position, point.rotation, point);

        private void OnHit(Vector3 position, Vector3 normal)
        {
            var rotation = Quaternion.LookRotation(normal);
            _effectsService.Fire(EffectId.Blood, position, rotation);
        }
    }
}