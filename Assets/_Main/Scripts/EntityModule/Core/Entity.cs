using UnityEngine;
using Zenject;

namespace EntityModule
{
    public class Entity : MonoBehaviour, IEntity
    {
        [SerializeField] private GameObjectContext context;

        private DiContainer _container;

        private void Awake() => _container = context.Container;

        public T Get<T>() where T : class => _container.Resolve<T>();

        public bool TryGet<T>(out T value) where T : class
        {
            value = _container.TryResolve<T>();
            return value != null;
        }
    }
}