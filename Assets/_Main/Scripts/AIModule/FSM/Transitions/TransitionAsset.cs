using System;
using Zenject;

namespace AIModule
{
    [Serializable]
    public class TransitionAsset : StateTransitionAsset<StateName, GameObjectContext> { }
}