using UnityEngine;

namespace InputModule
{
    public interface IInputMap
    {
        Vector3 Direction { get; }
        bool Jump { get; }
        bool Crouch { get; }
    }
}