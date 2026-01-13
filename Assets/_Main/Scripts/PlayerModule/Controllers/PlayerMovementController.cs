using ComponentsModule;
using CoreModule;
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
        private readonly IInputMap _inputMap;

        private readonly IPauseService _pauseService;

        public PlayerMovementController(IJumpComponent jumper,
            IMoveComponent mover,
            ICrouchComponent croucher,
            IRotationComponent rotater,
            IInputMap inputMap,
            IPauseService pauseService)
        {
            _jumper = jumper;
            _mover = mover;
            _inputMap = inputMap;
            _pauseService = pauseService;
            _rotater = rotater;
            _croucher = croucher;
        }

        public void Tick()
        {
            if (_pauseService.IsPaused)
            {
                _mover.Move(Vector3.zero);
                return;
            }

            Move();
            Jump();
            Crouch();
            Rotate();
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

        private void Rotate()
        {
            var angle = _inputMap.RotationAngle;
            _rotater.Rotate(angle);
        }
    }
}