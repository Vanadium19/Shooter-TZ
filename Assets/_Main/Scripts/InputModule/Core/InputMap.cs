using UnityEngine;

namespace InputModule
{
    public class InputMap : IInputMap
    {
        private const string HorizontalAxis = "Horizontal";
        private const string VerticalAxis = "Vertical";

        private const string RotateAxis = "Mouse X";
        private const string CameraAxis = "Mouse Y";

        public Vector3 Direction
            => Input.GetAxisRaw(HorizontalAxis) * Vector3.right
               + Input.GetAxisRaw(VerticalAxis) * Vector3.forward;

        public float PeekDirection => GetPeekDirection();
        public float RotationAngle => Input.GetAxisRaw(RotateAxis);
        public float CameraAngle => Input.GetAxisRaw(CameraAxis);
        public bool Jump => Input.GetKeyDown(KeyCode.Space);
        public bool Crouch => Input.GetKeyDown(KeyCode.LeftControl);
        public bool Attack => Input.GetMouseButtonDown(0);

        private float GetPeekDirection()
        {
            var direction = 0f;

            if (Input.GetKey(KeyCode.Q))
                direction -= 1f;

            if (Input.GetKey(KeyCode.E))
                direction += 1f;

            return direction;
        }
    }
}