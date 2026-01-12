using ComponentsModule;
using EntityModule;
using UnityEngine;
using Zenject;

namespace PlayerModule
{
    public class PlayerInstaller : MonoInstaller
    {
        [Header("References")]
        [SerializeField] private Rigidbody rigidbody;
        [SerializeField] private Entity entity;

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
        [SerializeField] private float deltaY = 0.5f;

        [Header("Rotation Settings")]
        [SerializeField] private float rotationSensitivity = 3f;

        [Header("Cover Settings")]
        [SerializeField] private Transform coverPoint;
        [SerializeField] private float coverRadius = 1.25f;
        [SerializeField] private LayerMask coverMask;
        [SerializeField] private float peekDistance = 0.4f;

        [Header("Health Settings")]
        [SerializeField] private int maxHealth = 5;

        private void OnValidate()
        {
            rigidbody ??= GetComponent<Rigidbody>();
            entity ??= GetComponent<Entity>();
        }

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
                .WithArguments(upBodyPart, deltaY);

            Container.BindInterfacesTo<MoveComponent>()
                .AsSingle()
                .WithArguments(moveSpeed);

            Container.BindInterfacesTo<GroundChecker>()
                .AsSingle()
                .WithArguments(overlapPoint, overlapRadius, overlapMask);

            Container.BindInterfacesTo<RotationComponent>()
                .AsSingle()
                .WithArguments(transform, rotationSensitivity);

            Container.BindInterfacesTo<CoverComponent>()
                .AsSingle()
                .WithArguments(coverPoint, coverRadius, coverMask, peekDistance);

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

            if (!coverPoint)
                return;

            Gizmos.DrawSphere(coverPoint.position, coverRadius);
        }
    }
}