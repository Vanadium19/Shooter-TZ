using System;

namespace ComponentsModule
{
    public interface IHealthComponent
    {
        event Action<int> HealthChanged;
        event Action Died;

        int MaxHealth { get; }
        int CurrentHealth { get; }

        void ApplyDamage(int damage);
    }
}