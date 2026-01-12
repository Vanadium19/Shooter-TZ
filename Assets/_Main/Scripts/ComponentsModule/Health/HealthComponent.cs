using System;
using UnityEngine;

namespace ComponentsModule
{
    public class HealthComponent : IHealthComponent
    {
        private readonly Transform _transform;
        private readonly int _maxHealth;

        private int _currentHealth;

        public event Action<int> HealthChanged;
        public event Action Died;

        public HealthComponent(Transform transform, int maxHealth)
        {
            _transform = transform;
            _maxHealth = maxHealth;
            _currentHealth = maxHealth;
        }

        public int CurrentHealth => _currentHealth;
        public int MaxHealth => _maxHealth;

        public void ApplyDamage(int damage)
        {
            if (_currentHealth <= 0)
                return;

            if (damage <= 0)
                return;

            _currentHealth = Mathf.Max(0, _currentHealth - damage);
            HealthChanged?.Invoke(_currentHealth);

            if (_currentHealth <= 0)
                Die();
        }

        private void Die()
        {
            // var root = GetRoot(_transform);
            // root.gameObject.SetActive(false);
            Died?.Invoke();
        }

        // private Transform GetRoot(Transform transform)
        // {
        //     while (transform.parent != null)
        //         transform = transform.parent;
        //
        //     return transform;
        // }
    }
}