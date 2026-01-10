using ComponentsModule;
using InputModule;
using Zenject;

namespace PlayerModule
{
    public class PlayerAttackController : ITickable
    {
        private readonly IAttackComponent _attacker;
        private readonly IInputMap _inputMap;

        public PlayerAttackController(IAttackComponent attacker, IInputMap inputMap)
        {
            _attacker = attacker;
            _inputMap = inputMap;
        }

        public void Tick()
        {
            if (_inputMap.Attack)
                _attacker.Attack();
        }
    }
}