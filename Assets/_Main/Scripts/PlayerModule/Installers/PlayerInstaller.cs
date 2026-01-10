using ComponentsModule;
using UnityEngine;
using Zenject;

namespace PlayerModule
{
    public class PlayerInstaller : MonoInstaller
    {
        [Header("References")]
        [SerializeField] private Rigidbody rigidbody;

        [Header("Move Settings")]
        [SerializeField] private float moveSpeed = 3f;

        [Header("Jump Settings")]
        [SerializeField] private float jumpForce = 5f;
        [SerializeField] private float jumpDelay = 2f;

        [Header("Ground Checker")]
        [SerializeField] private Transform overlapPoint;
        [SerializeField] private float overlapRadius;
        [SerializeField] private LayerMask overlapMask;

        private void OnValidate() => rigidbody ??= GetComponent<Rigidbody>();

        public override void InstallBindings()
        {
            Container.Bind<Rigidbody>()
                .FromInstance(rigidbody)
                .AsSingle();

            Container.BindInterfacesTo<JumpComponent>()
                .AsSingle()
                .WithArguments(jumpForce, jumpDelay, overlapMask);

            Container.BindInterfacesTo<MoveComponent>()
                .AsSingle()
                .WithArguments(moveSpeed);

            Container.BindInterfacesTo<GroundChecker>()
                .AsSingle()
                .WithArguments(overlapPoint, overlapRadius);

            Container.BindInterfacesTo<PlayerMovementController>()
                .AsSingle()
                .NonLazy();
        }

        private void OnDrawGizmos()
        {
            if (!overlapPoint)
                return;

            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(overlapPoint.position, overlapRadius);
        }
    }
}