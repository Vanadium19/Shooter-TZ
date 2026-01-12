using System;

namespace RootModule
{
    public interface IGameService
    {
        event Action Restarted;

        void Restart();
        void Exit();
    }
}