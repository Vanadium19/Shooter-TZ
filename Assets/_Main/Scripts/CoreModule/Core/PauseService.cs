using System;

namespace CoreModule
{
    public class PauseService : IPauseService
    {
        private bool _isPause;

        public event Action Paused;
        public event Action Resumed;

        public bool IsPaused => _isPause;

        public void Pause()
        {
            _isPause = true;
            Paused?.Invoke();
        }

        public void Continue()
        {
            _isPause = false;
            Resumed?.Invoke();
        }
    }
}