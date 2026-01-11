using ComponentsModule;
using InputModule;
using UnityEngine;
using Zenject;

namespace PlayerModule
{
    public class PlayerMovementController : ITickable
    {
        private readonly IJumpComponent _jumper;
        private readonly IMoveComponent _mover;
        private readonly ICrouchComponent _croucher;
        private readonly IRotationComponent _rotater;
        private readonly ICoverComponent _coverer;

        private readonly IInputMap _inputMap;

        public PlayerMovementController(IJumpComponent jumper,
            IMoveComponent mover,
            ICrouchComponent croucher,
            IRotationComponent rotater,
            ICoverComponent coverer,
            IInputMap inputMap)
        {
            _jumper = jumper;
            _mover = mover;
            _inputMap = inputMap;
            _rotater = rotater;
            _croucher = croucher;
            _coverer = coverer;
        }

        public void Tick()
        {
            Move();
            Jump();
            Crouch();
            Cover();
            Rotate();
        }

        private void Move()
        {
            var direction = _inputMap.Direction;

            if (_coverer.IsInCover)
                direction = Vector3.ProjectOnPlane(direction, _coverer.CoverNormal);

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

        private void Rotate()
        {
            var angle = _inputMap.RotationAngle;
            _rotater.Rotate(angle);
        }

        private void Cover()
        {
            if (!_inputMap.Cover)
                return;

            if (_coverer.IsInCover)
                _coverer.ExitCover();
            else
                _coverer.TryEnterCover();
        }
    }
}
