using EntityModule;
using PlayerModule;
using UnityEngine;
using Zenject;

namespace AIModule
{
    public class PlayerSensor : MonoBehaviour
    {
        private Blackboard _blackboard;

        [Inject]
        public void Construct(Blackboard blackboard)
        {
            _blackboard = blackboard;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out IEntity entity))
                return;

            if (!entity.TryGet(out PlayerTag playerTag))
                return;

            _blackboard.SetObject(BlackboardTag.Target, entity.Get<Transform>());
        }
    }
}