using System;

namespace RootModule
{
    public interface ILevelService
    {
        event Action<bool> GameFinished;
    }
}