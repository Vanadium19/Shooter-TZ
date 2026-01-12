using System;
using EntityModule;
using PlayerModule;
using UnityEngine;

namespace MainModule
{
    public class TimeZone : MonoBehaviour
    {
        [SerializeField] private float winDuration = 7f;

        private IEntity _player;

        private float _elapsedTime;
        private bool _isActive;

        public event Action TimeReached;

        private void Update()
        {
            if (!_isActive)
                return;

            _elapsedTime += Time.deltaTime;

            if (_elapsedTime < winDuration)
                return;

            TimeReached?.Invoke();
            Reset();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_player != null)
                return;

            if (!other.TryGetComponent(out IEntity entity))
                return;

            if (!entity.TryGet(out PlayerTag tag))
                return;

            _player = entity;
            _elapsedTime = 0f;
            _isActive = true;
        }

        private void OnTriggerExit(Collider other)
        {
            if (_player == null)
                return;

            if (!other.TryGetComponent(out IEntity entity))
                return;

            if (!entity.TryGet(out PlayerTag tag))
                return;

            Reset();
        }

        private void Reset()
        {
            _player = null;
            _elapsedTime = 0f;
            _isActive = false;
        }
    }
}