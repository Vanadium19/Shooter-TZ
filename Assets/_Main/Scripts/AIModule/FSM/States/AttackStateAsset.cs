using System;
using FSMModule;
using UnityEngine;
using Zenject;

namespace AIModule.States
{
    [Serializable]
    public class AttackStateAsset : IStateAsset<GameObjectContext>
    {
        [SerializeField] private float stoppingDistance = 2f;

        public IState Create(GameObjectContext context)
            => context.Container.Instantiate<AttackState>(new object[]
            {
                stoppingDistance,
            });
    }
}