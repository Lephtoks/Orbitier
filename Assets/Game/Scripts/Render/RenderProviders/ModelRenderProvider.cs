using System;
using UnityEngine;

namespace Game.Scripts.Render.RenderProviders
{
    public class ModelRenderProvider : RenderProvider
    {
        private readonly Model model;
        protected readonly Func<Vector2> positionProvider;

        public ModelRenderProvider(Model model, Func<Vector2> positionProvider)
        {
            this.model = model;
            this.positionProvider = positionProvider;
        }
        public override void Render()
        {
            Model.RenderModel(model, positionProvider.Invoke());
        }
    }
}