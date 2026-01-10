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

        [Header("Crouch Settings")]
        [SerializeField] private Transform upBodyPart;

        [Header("Rotation Settings")]
        [SerializeField] private float rotationSensitivity = 3f;

        [Header("Health Settings")]
        [SerializeField] private int maxHealth = 5;

        private void OnValidate() => rigidbody ??= GetComponent<Rigidbody>();

        public override void InstallBindings()
        {
            Container.Bind<Rigidbody>()
                .FromInstance(rigidbody)
                .AsSingle();

            Container.BindInterfacesTo<JumpComponent>()
                .AsSingle()
                .WithArguments(jumpForce, jumpDelay);

            Container.BindInterfacesTo<CrouchComponent>()
                .AsSingle()
                .WithArguments(upBodyPart);

            Container.BindInterfacesTo<MoveComponent>()
                .AsSingle()
                .WithArguments(moveSpeed);

            Container.BindInterfacesTo<GroundChecker>()
                .AsSingle()
                .WithArguments(overlapPoint, overlapRadius, overlapMask);

            Container.BindInterfacesTo<RotationComponent>()
                .AsSingle()
                .WithArguments(transform, rotationSensitivity);

            Container.BindInterfacesTo<HealthComponent>()
                .AsSingle()
                .WithArguments(maxHealth)
                .NonLazy();

            Container.BindInterfacesTo<AttackComponent>()
                .AsSingle();

            Container.BindInterfacesTo<PlayerMovementController>()
                .AsSingle()
                .NonLazy();

            Container.BindInterfacesTo<PlayerAttackController>()
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