using UnityEngine;

namespace ComponentsModule
{
    public interface ICoverComponent
    {
        bool IsInCover { get; }
        Vector3 CoverNormal { get; }
        bool TryEnterCover();
        void ExitCover();
    }
}
