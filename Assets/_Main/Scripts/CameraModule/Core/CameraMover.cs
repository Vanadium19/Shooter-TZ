using UnityEngine;

namespace CameraModule
{
    public class CameraMover : ICameraMover
    {
        private readonly Transform _transform;

        private readonly float _sensitivity;
        private readonly float _verticalMinAngle;
        private readonly float _verticalMaxAngle;

        private float _verticalAngle;
        private Vector3 _baseLocalPosition;
        private Vector3 _offset;

        public CameraMover(float sensitivity, float verticalMinAngle, float verticalMaxAngle)
        {
            _sensitivity = sensitivity;
            _verticalMinAngle = verticalMinAngle;
            _verticalMaxAngle = verticalMaxAngle;

            _transform = Camera.main!.transform;
            _verticalAngle = _transform.localEulerAngles.x;
            _baseLocalPosition = _transform.localPosition;
            _offset = Vector3.zero;
        }

        public void RotateY(float angle)
        {
            var horizontalAngle = _transform.eulerAngles.y;

            _verticalAngle -= angle * _sensitivity * Time.deltaTime;
            _verticalAngle = Mathf.Clamp(_verticalAngle, _verticalMinAngle, _verticalMaxAngle);

            _transform.rotation = Quaternion.Euler(_verticalAngle, horizontalAngle, 0);
        }

        public void MoveY(float delta)
        {
            _baseLocalPosition.y += delta;
            UpdatePosition();
        }

        public void SetOffset(Vector3 offset)
        {
            _offset = offset;
            UpdatePosition();
        }

        private void UpdatePosition()
        {
            _transform.localPosition = _baseLocalPosition + _offset;
        }
    }
}
