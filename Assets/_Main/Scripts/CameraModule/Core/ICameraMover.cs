namespace CameraModule
{
    public interface ICameraMover
    {
        void RotateY(float angle);
        void MoveY(float delta);
    }
}