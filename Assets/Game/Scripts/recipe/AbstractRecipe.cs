using Game.Scripts.block.link;

namespace Game.Scripts.recipe
{
    public abstract class AbstractRecipe<T>
    {
        public abstract bool CanPass(Link itemLink, int stage, ref T data);
        
    }
}