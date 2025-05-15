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
            foreach (var modelEntry in model.Entries)
            {
                // GL.PushMatrix();
                // GL.LoadProjectionMatrix(Matrix4x4.Rotate(Quaternion.Euler(0, 0, modelEntry.Rotation)));
                Graphics.DrawTexture(new Rect(this.positionProvider.Invoke()+modelEntry.Offset, modelEntry.Size), modelEntry.Texture);
                // GL.PopMatrix();
            }
        }
    }
}