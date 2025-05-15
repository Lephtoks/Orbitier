using Game.Scripts.Blocks.Links;

namespace Game.Scripts.Recipe
{
    public abstract class AbstractRecipe<T>
    {
        public abstract bool CanPass(Link itemLink, int stage, ref T data);
        
    }
}