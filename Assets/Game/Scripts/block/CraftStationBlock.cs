using Game.Scripts.block.link;
using Game.Scripts.tile;

namespace Game.Scripts.block
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