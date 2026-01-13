using System;
using UnityEngine;

namespace CoreModule
{
    public class GameService : IGameService
    {
        private readonly IPauseService _pauseService;

        public GameService(IPauseService pauseService)
        {
            _pauseService = pauseService;
        }

        public event Action Restarted;

        public void Restart()
        {
            _pauseService.Continue();
            Restarted?.Invoke();
        }

        public void Exit()
        {
            Application.Quit();

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }
}