using System;
using ComponentsModule;
using PlayerModule;
using UnityEngine;
using Zenject;
using TimeZone = MainModule.TimeZone;

namespace RootModule
{
    public class LevelService : IInitializable, IDisposable, ILevelService
    {
        private readonly TimeZone _winZone;
        private readonly PlayerProvider _playerProvider;

        private IHealthComponent _playerHealth;

        public LevelService(TimeZone winZone, PlayerProvider playerProvider)
        {
            _winZone = winZone;
            _playerProvider = playerProvider;
        }

        public event Action<bool> GameFinished;

        public void Initialize()
        {
            _winZone.TimeReached += Win;
            _playerHealth = _playerProvider.Get<IHealthComponent>();
            _playerHealth.Died += Lose;
        }

        public void Dispose()
        {
            _winZone.TimeReached -= Win;
            _playerHealth.Died -= Lose;
        }

        private void Win() => GameFinished?.Invoke(true);

        private void Lose() => GameFinished?.Invoke(false);
    }
}