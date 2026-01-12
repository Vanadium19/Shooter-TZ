using UnityEngine;

namespace ComponentsModule
{
    public interface ICoverComponent
    {
        float PeekDistance { get; }
        bool IsCoverNearby { get; }
    }
}