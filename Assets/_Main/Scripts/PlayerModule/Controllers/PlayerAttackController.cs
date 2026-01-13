using ComponentsModule;
using CoreModule;
using InputModule;
using Zenject;

namespace PlayerModule
{
    public class PlayerAttackController : ITickable
    {
        private readonly IAttackComponent _attacker;
        private readonly IInputMap _inputMap;

        private readonly IPauseService _pauseService;

        public PlayerAttackController(IAttackComponent attacker,
            IInputMap inputMap,
            IPauseService pauseService)
        {
            _attacker = attacker;
            _inputMap = inputMap;
            _pauseService = pauseService;
        }

        public void Tick()
        {
            if (_pauseService.IsPaused)
                return;

            if (_inputMap.Attack)
                _attacker.Attack();
        }
    }
}