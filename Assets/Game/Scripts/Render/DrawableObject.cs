namespace Game.Scripts.Render
{
    public abstract class DrawableObject
    {
        private RenderProvider _current;
        protected virtual RenderProvider GenerateRenderProvider() => null;


        public RenderProvider GetRenderProvider()
        {
            return this._current ??= GenerateRenderProvider();
        }
    }
}