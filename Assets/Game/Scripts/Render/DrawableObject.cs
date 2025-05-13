namespace Game.Scripts.Render
{
    public abstract class DrawableObject
    {
        protected virtual RenderProvider renderProvider => null;

        public RenderProvider GetRenderProvider()
        {
            return this.renderProvider;
        }
    }
}