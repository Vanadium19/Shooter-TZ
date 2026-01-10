using ComponentsModule;
using InputModule;
using Zenject;

namespace PlayerModule
{
    public class PlayerMovementController : ITickable
    {
        private readonly IJumpComponent _jumper;
        private readonly IMoveComponent _mover;
        private readonly ICrouchComponent _croucher;

        private readonly IInputMap _inputMap;

        public PlayerMovementController(IJumpComponent jumper,
            IMoveComponent mover,
            ICrouchComponent croucher,
            IInputMap inputMap)
        {
            _jumper = jumper;
            _mover = mover;
            _inputMap = inputMap;
            _croucher = croucher;
        }

        public void Tick()
        {
            Move();
            Jump();
            Crouch();
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

        private void Crouch()
        {
            if (_inputMap.Crouch)
                _croucher.Toggle();
        }
    }
}