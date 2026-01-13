using System;
using ComponentsModule;
using CoreModule;
using UnityEngine;
using Zenject;

namespace PlayerModule
{
    public class PlayerRestartController : IInitializable, IDisposable
    {
        private readonly IGameService _gameService;
        private readonly IHealthComponent _healthComponent;
        private readonly Transform _transform;

        private Vector3 _startPosition;

        public PlayerRestartController(IGameService gameService,
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
            _gameService.Restarted += OnRestarted;
        }

        public void Dispose()
        {
            _gameService.Restarted -= OnRestarted;
        }

        private void OnRestarted()
        {
            _transform.position = _startPosition;
            _healthComponent.Reset();
        }
    }
}