using UnityEngine;

namespace ComponentsModule
{
    public class TargetRotationComponent : ITargetRotationComponent
    {
        private readonly Transform _transform;
        private readonly float _speed;

        private float _horizontalAngle;

        public TargetRotationComponent(Transform transform, float speed)
        {
            _transform = transform;
            _speed = speed;
        }

        public void Rotate(Vector3 target)
        {
            var direction = Vector3.ProjectOnPlane(target - _transform.position, Vector3.up).normalized;
            var rotation = Quaternion.LookRotation(direction);
            _transform.rotation = Quaternion.Slerp(_transform.rotation, rotation, _speed * Time.deltaTime);
        }
    }
}