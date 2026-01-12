using System;
using ComponentsModule;
using UIModule;
using Zenject;

namespace PlayerModule
{
    public class PlayerPresenter : IInitializable, IDisposable
    {
        private readonly IHealthComponent _health;
        private readonly HealthView _view;

        public PlayerPresenter(IHealthComponent health, HealthView view)
        {
            _health = health;
            _view = view;
        }

        public void Initialize()
        {
            OnHealthChanged(_health.CurrentHealth);
            _health.HealthChanged += OnHealthChanged;
        }

        public void Dispose()
        {
            _health.HealthChanged -= OnHealthChanged;
        }

        private void OnHealthChanged(int currentHealth)
        {
            var fillAmount = (float)currentHealth / _health.MaxHealth;
            _view.SetHealth(fillAmount);
        }
    }
}