using System;

namespace ComponentsModule
{
    public interface ICrouchComponent
    {
        event Action Crouched;
        event Action Uncrouched;

        float DeltaY { get; }

        void Toggle();
        void Crouch();
        void Uncrouch();
    }
}