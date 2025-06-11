#nullable enable
using System.Collections.Generic;
using Game.Scripts.Data;
using UnityEngine;

namespace Game.Scripts.Render
{
    public class Model
    {
        public readonly List<ModelEntry> Entries;

        public Model(List<ModelEntry> entries)
        {
            this.Entries = entries;
        }

        public static void RenderModel(Model model, Vector2 position)
        {
            foreach (var modelEntry in model.Entries)
            {
                var pos = position + modelEntry.Offset;
                GL.PushMatrix();
                GL.modelview = Camera.main.worldToCameraMatrix
                               * Matrix4x4.Translate(pos + modelEntry.Size/2)
                               * Matrix4x4.Rotate(Quaternion.Euler(0, 0, modelEntry.Rotation))
                               * Matrix4x4.Translate(-pos - modelEntry.Size/2)
                               * Matrix4x4.Translate(modelEntry.Offset);
                Graphics.DrawTexture(new Rect(pos - modelEntry.Offset, modelEntry.Size), modelEntry.Texture.texture, new Rect(modelEntry.Texture.u, modelEntry.Texture.v, modelEntry.Texture.width, modelEntry.Texture.height), );
                
                GL.PopMatrix();
            }
        }

        public record ModelEntry(TexturePart Texture, Vector2 Size, Vector2 Offset, Vector2 Pivot, float Rotation);
    }
}