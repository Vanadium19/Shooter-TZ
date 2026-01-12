using UnityEngine;
using Zenject;

namespace ComponentsModule
{
    public class JumpComponent : ITickable, IJumpComponent
    {
        private readonly IGroundChecker _groundChecker;
        private readonly Rigidbody _rigidbody;

        private readonly float _force;
        private readonly float _delay;

        private float _currentTime;

        public JumpComponent(IGroundChecker groundChecker, Rigidbody rigidbody, float force, float delay)
        {
            _groundChecker = groundChecker;
            _rigidbody = rigidbody;
            _force = force;
            _delay = delay;
        }

        public void Tick()
        {
            if (_currentTime <= 0)
                return;

            _currentTime -= Time.deltaTime;
        }

        public void Jump()
        {
            if (_currentTime > 0)
                return;

            if (!_groundChecker.IsGrounded)
                return;

            var force = Vector3.up * _force;
            _rigidbody.AddForce(force, ForceMode.Impulse);
            _currentTime = _delay;
        }
    }
}