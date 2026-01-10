using UnityEngine;

namespace InputModule
{
    public class InputMap : IInputMap
    {
        private const string HorizontalAxis = "Horizontal";
        private const string VerticalAxis = "Vertical";

        public Vector3 Direction
            => Input.GetAxisRaw(HorizontalAxis) * Vector3.right
               + Input.GetAxisRaw(VerticalAxis) * Vector3.forward;

        public bool Jump => Input.GetKeyDown(KeyCode.Space);
    }
}