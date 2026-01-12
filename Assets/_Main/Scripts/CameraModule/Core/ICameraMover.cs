using UnityEngine;

namespace CameraModule
{
    public interface ICameraMover
    {
        void RotateY(float angle);
        void MoveY(float delta);
        void SetOffset(Vector3 offset);
    }
}
