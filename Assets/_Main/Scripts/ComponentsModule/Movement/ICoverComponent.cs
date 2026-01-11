using UnityEngine;

namespace ComponentsModule
{
    public interface ICoverComponent
    {
        bool IsCoverNearby { get; }
        Vector3 CoverNormal { get; }
        void UpdateCoverState();
    }
}
