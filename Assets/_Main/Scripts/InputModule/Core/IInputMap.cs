using UnityEngine;

namespace InputModule
{
    public interface IInputMap
    {
        Vector3 Direction { get; }
        float RotationAngle { get; }
        float CameraAngle { get; }
        bool Jump { get; }
        bool Crouch { get; }
        bool Cover { get; }
        float PeekDirection { get; }
        bool Attack { get; }
    }
}
