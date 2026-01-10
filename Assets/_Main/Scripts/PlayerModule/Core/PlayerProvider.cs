using EntityModule;

namespace PlayerModule
{
    public class PlayerProvider : IEntity
    {
        private readonly IEntity _entity;

        public PlayerProvider(IEntity entity)
        {
            _entity = entity;
        }

        public T Get<T>() where T : class => _entity.Get<T>();

        public bool TryGet<T>(out T value) where T : class => _entity.TryGet<T>(out value);
    }
}