using CameraModule;
using ComponentsModule;
using InputModule;
using PlayerModule;
using UnityEngine;
using Zenject;

namespace MainModule
{
    public class CameraCoverPeekController : ITickable, IInitializable
    {
        private readonly PlayerProvider _playerProvider;
        private readonly ICameraMover _cameraMover;
        private readonly IInputMap _inputMap;

        private ICoverComponent _coverComponent;

        public CameraCoverPeekController(PlayerProvider playerProvider, ICameraMover cameraMover, IInputMap inputMap)
        {
            _playerProvider = playerProvider;
            _cameraMover = cameraMover;
            _inputMap = inputMap;
        }

        public void Initialize() => _coverComponent = _playerProvider.Get<ICoverComponent>();

        public void Tick() => UpdateCoverPeekOffset();

        private void UpdateCoverPeekOffset()
        {
            var targetOffset = _coverComponent.IsCoverNearby
                ? _coverComponent.PeekDistance * _inputMap.PeekDirection * Vector3.right
                : Vector3.zero;

            _cameraMover.SetOffset(targetOffset);
        }
    }
}