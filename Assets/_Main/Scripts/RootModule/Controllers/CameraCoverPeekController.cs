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
        private readonly float _peekDistance;
        private readonly float _peekSpeed;

        private ICoverComponent _coverComponent;
        private Transform _playerTransform;
        private Vector3 _currentOffset;

        public CameraCoverPeekController(PlayerProvider playerProvider, ICameraMover cameraMover, IInputMap inputMap,
            float peekDistance, float peekSpeed)
        {
            _playerProvider = playerProvider;
            _cameraMover = cameraMover;
            _inputMap = inputMap;
            _peekDistance = peekDistance;
            _peekSpeed = peekSpeed;
        }

        public void Initialize()
        {
            _coverComponent = _playerProvider.Get<ICoverComponent>();
            _playerTransform = _playerProvider.Get<Rigidbody>().transform;
        }

        public void Tick()
        {
            var targetOffset = Vector3.zero;

            if (_coverComponent.IsInCover)
            {
                var direction = _inputMap.PeekDirection;
                if (!Mathf.Approximately(direction, 0f))
                    targetOffset = _playerTransform.right * (_peekDistance * Mathf.Sign(direction));
            }

            _currentOffset = Vector3.Lerp(_currentOffset, targetOffset, _peekSpeed * Time.deltaTime);
            _cameraMover.SetOffset(_currentOffset);
        }
    }
}
