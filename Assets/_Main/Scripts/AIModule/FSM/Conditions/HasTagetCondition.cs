using System;
using UnityEngine;
using Zenject;

namespace AIModule
{
    [Serializable]
    public class HasTagetCondition : IConditionAsset<GameObjectContext>
    {
        [SerializeField] private bool invert;

        public Func<bool> Create(GameObjectContext context)
        {
            var blackboard = context.Container.Resolve<Blackboard>();
            return () => HasTarget(blackboard) == !invert;
        }

        private bool HasTarget(Blackboard blackboard) => blackboard.HasObject(BlackboardTag.Target);
    }
}