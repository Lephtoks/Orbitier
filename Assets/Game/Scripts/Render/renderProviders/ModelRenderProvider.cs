using System;
using UnityEngine;

namespace Game.Scripts.Render.renderProviders
{
    public class ModelRenderProvider : RenderProvider
    {
        private readonly Model model;
        private readonly Func<Vector2> positionProvider;

        public ModelRenderProvider(Model model, Func<Vector2> positionProvider)
        {
            this.model = model;
            this.positionProvider = positionProvider;
        }
        public override void Render()
        {
            Graphics.DrawTexture(new Rect(this.positionProvider.Invoke()+model.Offset, model.Size), model.Texture);
        }
    }
}