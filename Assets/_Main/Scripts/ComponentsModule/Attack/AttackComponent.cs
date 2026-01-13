namespace ComponentsModule
{
    public class AttackComponent : IAttackComponent
    {
        private readonly IWeapon _weapon;

        public AttackComponent(IWeapon weapon)
        {
            _weapon = weapon;
        }

        public void Attack()
        {
            if (_weapon == null)
                return;

            _weapon.Use();
        }
    }
}