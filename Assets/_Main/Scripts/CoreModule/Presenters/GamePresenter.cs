using System;
using UIModule;
using Zenject;

namespace CoreModule
{
    public class GamePresenter : IInitializable, IDisposable
    {
        private readonly IGameService _gameService;
        private readonly GameView _gameView;

        public GamePresenter(IGameService gameService, GameView gameView)
        {
            _gameService = gameService;
            _gameView = gameView;
        }

        public void Initialize()
        {
            _gameView.Restarted += _gameService.Restart;
            _gameView.Exited += _gameService.Exit;
        }

        public void Dispose()
        {
            _gameView.Restarted -= _gameService.Restart;
            _gameView.Exited -= _gameService.Exit;
        }
    }
}