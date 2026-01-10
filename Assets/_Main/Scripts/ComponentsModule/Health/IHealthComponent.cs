using System;

namespace ComponentsModule
{
    public interface IHealthComponent
    {
        event Action<int> HealthChanged;
        event Action Died;

        void ApplyDamage(int damage);
    }
}