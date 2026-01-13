using System;
using CoreModule;
using UIModule;
using Zenject;

namespace RootModule
{
    public class LevelPresenter : IInitializable, IDisposable
    {
        private readonly IPauseService _pauseService;

        private readonly ILevelService _levelService;
        private readonly GameView _gameView;

        public LevelPresenter(IPauseService pauseService,
            ILevelService levelService,
            GameView gameView)
        {
            _pauseService = pauseService;
            _levelService = levelService;
            _gameView = gameView;
        }

        public void Initialize() => _levelService.GameFinished += OnGameFinished;

        public void Dispose() => _levelService.GameFinished -= OnGameFinished;

        private void OnGameFinished(bool isWon)
        {
            _gameView.ShowPanel(isWon);
            _pauseService.Pause();
        }
    }
}