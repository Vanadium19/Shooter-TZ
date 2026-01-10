namespace ComponentsModule
{
    public interface IWeapon
    {
        bool IsReady { get; }
        void Use();
    }
}