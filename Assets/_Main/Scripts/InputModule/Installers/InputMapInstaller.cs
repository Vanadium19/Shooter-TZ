using UnityEngine;
using Zenject;

namespace InputModule
{
    [CreateAssetMenu(fileName = "InputMapInstaller", menuName = "Game/Installers/InputMapInstaller")]
    public class InputMapInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<InputMap>()
                .AsSingle()
                .NonLazy();
        }
    }
}