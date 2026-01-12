using System;

namespace CoreModule
{
    public interface IPauseService
    {
        event Action Paused;
        event Action Resumed;

        bool IsPaused { get; }

        void Pause();
        void Continue();
    }
}