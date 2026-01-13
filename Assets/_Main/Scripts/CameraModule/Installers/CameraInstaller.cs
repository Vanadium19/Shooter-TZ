using UnityEngine;
using Zenject;

namespace CameraModule
{
    [CreateAssetMenu(fileName = "CameraInstaller", menuName = "Game/Installers/CameraInstaller")]
    public class CameraInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private float _sensitivity = 100;
        [SerializeField] private float _verticalMinAngle = 100;
        [SerializeField] private float _verticalMaxAngle = 30;
        [SerializeField] private float peekSpeed = 8f;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<CameraMover>()
                .AsSingle()
                .WithArguments(_sensitivity, _verticalMinAngle, _verticalMaxAngle, peekSpeed);

            Container.BindInterfacesTo<CameraController>()
                .AsSingle()
                .NonLazy();
        }
    }
}