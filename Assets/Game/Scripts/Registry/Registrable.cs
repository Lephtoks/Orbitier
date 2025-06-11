#nullable enable
namespace Game.Scripts.Registry
{
    public interface Registrable
    {
        public void OnRegister(in Identifier item) {}
    }
}