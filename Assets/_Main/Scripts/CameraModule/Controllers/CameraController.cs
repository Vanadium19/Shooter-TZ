using InputModule;
using Zenject;

namespace CameraModule
{
    public class CameraController : ILateTickable
    {
        private readonly ICameraMover _cameraMover;
        private readonly IInputMap _inputMap;

        public CameraController(ICameraMover cameraMover, IInputMap inputMap)
        {
            _cameraMover = cameraMover;
            _inputMap = inputMap;
        }

        public void LateTick() => Move();

        private void Move()
        {
            var angle = _inputMap.CameraAngle;
            _cameraMover.Move(angle);
        }
    }
}