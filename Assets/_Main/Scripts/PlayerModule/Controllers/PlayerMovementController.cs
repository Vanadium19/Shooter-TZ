using ComponentsModule;
using InputModule;
using Zenject;

namespace PlayerModule
{
    public class PlayerMovementController : ITickable
    {
        private readonly IJumpComponent _jumper;
        private readonly IMoveComponent _mover;

        private readonly IInputMap _inputMap;

        public PlayerMovementController(IJumpComponent jumper, IMoveComponent mover, IInputMap inputMap)
        {
            _jumper = jumper;
            _mover = mover;
            _inputMap = inputMap;
        }

        public void Tick()
        {
            Move();
            Jump();
        }

        private void Move()
        {
            var direction = _inputMap.Direction;
            _mover.Move(direction);
        }

        private void Jump()
        {
            if (_inputMap.Jump)
                _jumper.Jump();
        }
    }
}