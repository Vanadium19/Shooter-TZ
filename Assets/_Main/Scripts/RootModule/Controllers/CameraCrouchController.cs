using System;
using CameraModule;
using ComponentsModule;
using PlayerModule;
using Zenject;

namespace MainModule
{
    public class CameraCrouchController : IInitializable, IDisposable
    {
        private readonly PlayerProvider _playerProvider;
        private readonly ICameraMover _cameraMover;

        private ICrouchComponent _crouchComponent;

        public CameraCrouchController(PlayerProvider playerProvider, ICameraMover cameraMover)
        {
            _playerProvider = playerProvider;
            _cameraMover = cameraMover;
        }

        public void Initialize()
        {
            _crouchComponent = _playerProvider.Get<ICrouchComponent>();

            _crouchComponent.Crouched += OnCrouched;
            _crouchComponent.Uncrouched += OnUncrouched;
        }

        public void Dispose()
        {
            _crouchComponent.Crouched -= OnCrouched;
            _crouchComponent.Uncrouched -= OnUncrouched;
        }

        private void OnCrouched() => _cameraMover.MoveY(-_crouchComponent.DeltaY);

        private void OnUncrouched() => _cameraMover.MoveY(_crouchComponent.DeltaY);
    }
}