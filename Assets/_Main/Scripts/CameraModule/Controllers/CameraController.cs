using CoreModule;
using InputModule;
using Zenject;

namespace CameraModule
{
    public class CameraController : ILateTickable
    {
        private readonly ICameraMover _cameraMover;
        private readonly IInputMap _inputMap;

        private readonly IPauseService _pauseService;

        public CameraController(ICameraMover cameraMover,
            IInputMap inputMap,
            IPauseService pauseService)
        {
            _cameraMover = cameraMover;
            _inputMap = inputMap;
            _pauseService = pauseService;
        }

        public void LateTick()
        {
            if (_pauseService.IsPaused)
                return;

            Move();
        }

        private void Move()
        {
            var angle = _inputMap.CameraAngle;
            _cameraMover.RotateY(angle);
        }
    }
}