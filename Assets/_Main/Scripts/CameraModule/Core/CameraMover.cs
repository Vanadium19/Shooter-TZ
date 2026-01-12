using UnityEngine;

namespace CameraModule
{
    public class CameraMover : ICameraMover
    {
        private readonly Transform _transform;

        private readonly float _sensitivity;
        private readonly float _verticalMinAngle;
        private readonly float _verticalMaxAngle;
        private readonly float _offsetSpeed;

        private float _verticalAngle;
        private Vector3 _baseLocalPosition;
        private Vector3 _offset;

        public CameraMover(float sensitivity, float verticalMinAngle, float verticalMaxAngle, float offsetSpeed)
        {
            _sensitivity = sensitivity;
            _verticalMinAngle = verticalMinAngle;
            _verticalMaxAngle = verticalMaxAngle;
            _offsetSpeed = offsetSpeed;

            _transform = Camera.main!.transform;
            _verticalAngle = _transform.localEulerAngles.x;
            _baseLocalPosition = _transform.localPosition;
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
            _transform.localPosition = _baseLocalPosition + _offset;
        }

        public void SetOffset(Vector3 offset)
        {
            _offset = Vector3.Lerp(_offset, offset, _offsetSpeed * Time.deltaTime);
            _transform.localPosition = _baseLocalPosition + _offset;
        }
    }
}