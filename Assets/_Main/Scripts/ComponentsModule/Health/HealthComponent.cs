using System;
using UnityEngine;

namespace ComponentsModule
{
    public class HealthComponent : IHealthComponent
    {
        private readonly int _maxHealth;

        private int _currentHealth;

        public event Action<int> HealthChanged;
        public event Action Died;

        public HealthComponent(int maxHealth)
        {
            _maxHealth = maxHealth;
            _currentHealth = maxHealth;
        }

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
            Debug.Log("Entity died.");
            Died?.Invoke();
        }
    }
}