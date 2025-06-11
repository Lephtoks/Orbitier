#nullable enable
using Game.Scripts.Blocks.Links;
using Game.Scripts.Tiling;

namespace Game.Scripts.Blocks
{
    public abstract class CraftStationBlock : LinkableBlock
    {
        protected int stage;

        public CraftStationBlock() : base()
        {
        }

        public sealed override void Transfer(Link from)
        {
            if (Input(from))
            {
                stage++;
            }
        }

        protected abstract bool Input(Link from);
    }
}