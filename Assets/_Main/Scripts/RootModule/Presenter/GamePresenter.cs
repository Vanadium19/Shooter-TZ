using System;
using CoreModule;
using UIModule;
using Zenject;

namespace RootModule
{
    public class GamePresenter : IInitializable, IDisposable
    {
        private readonly IPauseService _pauseService;
        private readonly IGameService _gameService;
        private readonly GameView _gameView;

        public GamePresenter(IPauseService pauseService,
            IGameService gameService,
            GameView gameView)
        {
            _gameService = gameService;
            _gameView = gameView;
            _pauseService = pauseService;
        }

        public void Initialize()
        {
            _gameView.Restarted += OnRestarted;
            _gameView.Exited += _gameService.Exit;
        }

        public void Dispose()
        {
            _gameView.Restarted -= OnRestarted;
            _gameView.Exited -= _gameService.Exit;
        }

        private void OnRestarted()
        {
            _gameService.Restart();
            _pauseService.Continue();
        }
    }
}