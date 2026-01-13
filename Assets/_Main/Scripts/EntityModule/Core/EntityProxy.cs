using UnityEngine;

namespace EntityModule
{
    public class EntityProxy : MonoBehaviour, IEntity
    {
        [SerializeField] private Entity entity;

        public T Get<T>() where T : class => entity.Get<T>();

        public bool TryGet<T>(out T value) where T : class => entity.TryGet(out value);
    }
}