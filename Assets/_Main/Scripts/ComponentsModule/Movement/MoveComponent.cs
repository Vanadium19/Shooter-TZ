using UnityEngine;

namespace ComponentsModule
{
    public class MoveComponent : IMoveComponent
    {
        private readonly Rigidbody _rigidbody;
        private readonly float _speed;

        public MoveComponent(Rigidbody rigidbody, float speed)
        {
            _rigidbody = rigidbody;
            _speed = speed;
        }

        public void Move(Vector3 direction)
        {
            var velocity = direction * _speed;
            velocity.y = _rigidbody.linearVelocity.y;
            _rigidbody.linearVelocity = velocity;
        }
    }
}