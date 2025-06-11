#nullable enable
using Game.Scripts.Tiling;

namespace Game.Scripts.World
{
    public interface Hoverable
    {
        Shape GetHoverShape();
    }
}