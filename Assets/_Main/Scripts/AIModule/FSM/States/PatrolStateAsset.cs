using System;
using FSMModule;
using UnityEngine;
using Zenject;

namespace AIModule.States
{
    [Serializable]
    public class PatrolStateAsset : IStateAsset<GameObjectContext>
    {
        [SerializeField] private Transform[] points;
        [SerializeField] private float lappingDistance = 0.1f;

        public IState Create(GameObjectContext context)
            => context.Container.Instantiate<PatrolState>(new object[]
            {
                points,
                lappingDistance,
            });
    }
}