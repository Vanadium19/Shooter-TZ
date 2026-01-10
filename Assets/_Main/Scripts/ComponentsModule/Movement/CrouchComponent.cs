using UnityEngine;

namespace ComponentsModule
{
    public class CrouchComponent : ICrouchComponent
    {
        private readonly Transform _upPart;

        private bool _isCrouching;

        public CrouchComponent(Transform upPart)
        {
            _upPart = upPart;
        }

        public void Toggle()
        {
            if (_isCrouching)
                Uncrouch();
            else
                Crouch();
        }

        public void Crouch()
        {
            if (_isCrouching)
                return;

            _isCrouching = true;
            _upPart.gameObject.SetActive(true);
        }

        public void Uncrouch()
        {
            if (!_isCrouching)
                return;

            _isCrouching = false;
            _upPart.gameObject.SetActive(false);
        }
    }
}