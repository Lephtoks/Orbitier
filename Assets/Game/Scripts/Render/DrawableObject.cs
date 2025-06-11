#nullable enable
namespace Game.Scripts.Render
{
    public abstract class DrawableObject
    {
        private RenderProvider _current;
        protected virtual RenderProvider RenderProvider => null;


        public RenderProvider GetRenderProvider()
        {
            return this._current ??= RenderProvider;
        }
    }
}