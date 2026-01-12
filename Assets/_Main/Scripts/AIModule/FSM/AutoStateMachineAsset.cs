using System;
using FSMModule;
using Zenject;

namespace AIModule
{
    [Serializable]
    public class AutoStateMachineAsset : AutoStateMachineAsset<StateName, GameObjectContext> { }
}