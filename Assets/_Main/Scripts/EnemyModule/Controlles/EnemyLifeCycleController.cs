using System;
using ComponentsModule;
using CoreModule;
using UnityEngine;
using Zenject;

namespace EnemyModule
{
    public class EnemyLifeCycleController : IInitializable, IDisposable
    {
        private readonly IHealthComponent _healthComponent;
        private readonly IGameService _gameService;
        private readonly Transform _transform;

        private Vector3 _startPosition;

        public EnemyLifeCycleController(IGameService gameService,
            IHealthComponent healthComponent,
            Transform transform)
        {
            _gameService = gameService;
            _healthComponent = healthComponent;
            _transform = transform;
        }

        public void Initialize()
        {
            _startPosition = _transform.position;
            _healthComponent.Died += OnDied;
            _gameService.Restarted += OnRestarted;
        }

        public void Dispose()
        {
            _healthComponent.Died -= OnDied;
            _gameService.Restarted -= OnRestarted;
        }

        private void OnDied()
        {
            var root = GetRoot(_transform);
            root.gameObject.SetActive(false);
        }

        private void OnRestarted()
        {
            var root = GetRoot(_transform);
            root.gameObject.SetActive(true);
            _transform.position = _startPosition;
            _healthComponent.Reset();
        }

        private Transform GetRoot(Transform transform)
        {
            while (transform.parent != null)
                transform = transform.parent;

            return transform;
        }
    }
}