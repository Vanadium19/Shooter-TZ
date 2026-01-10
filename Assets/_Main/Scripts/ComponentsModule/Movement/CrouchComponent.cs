using System;
using UnityEngine;

namespace ComponentsModule
{
    public class CrouchComponent : ICrouchComponent
    {
        private readonly Transform _upPart;
        private readonly float _deltaY;

        private bool _isCrouching;

        public event Action Crouched;
        public event Action Uncrouched;

        public CrouchComponent(Transform upPart, float deltaY)
        {
            _upPart = upPart;
            _deltaY = deltaY;
        }

        public float DeltaY => _deltaY;

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
            Crouched?.Invoke();
        }

        public void Uncrouch()
        {
            if (!_isCrouching)
                return;

            _isCrouching = false;
            _upPart.gameObject.SetActive(false);
            Uncrouched?.Invoke();
        }
    }
}