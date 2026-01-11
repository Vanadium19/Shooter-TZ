using UnityEngine;

namespace ComponentsModule
{
    public class CoverComponent : ICoverComponent
    {
        private readonly Transform _origin;
        private readonly float _checkDistance;
        private readonly LayerMask _coverMask;

        public CoverComponent(Transform origin, float checkDistance, LayerMask coverMask)
        {
            _origin = origin;
            _checkDistance = checkDistance;
            _coverMask = coverMask;
        }

        public bool IsCoverNearby { get; private set; }
        public Vector3 CoverNormal { get; private set; }

        public void UpdateCoverState()
        {
            if (!Physics.Raycast(_origin.position, _origin.forward, out var hit, _checkDistance, _coverMask))
            {
                IsCoverNearby = false;
                CoverNormal = Vector3.zero;
                return;
            }

            IsCoverNearby = true;
            CoverNormal = hit.normal;
        }
    }
}
