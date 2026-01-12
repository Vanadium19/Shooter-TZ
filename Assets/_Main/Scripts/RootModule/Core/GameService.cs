using System;
using UnityEngine;

namespace RootModule
{
    public class GameService : IGameService
    {
        public event Action Restarted;

        public void Restart() { }

        public void Exit()
        {
            Application.Quit();

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }
}