using System;

namespace CoreModule
{
    public interface IGameService
    {
        event Action Restarted;

        void Restart();
        void Exit();
    }
}