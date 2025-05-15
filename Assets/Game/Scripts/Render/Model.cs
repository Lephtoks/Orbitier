using System.Collections.Generic;
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

        public static Model Of(Texture Texture, Vector2 Size, Vector2 Offset, float Rotation)
        {
            var list = new List<ModelEntry>();
            list.Add(new ModelEntry(Texture, Size, Offset, Rotation));
            return new Model(list);
        }

        public static void RenderModel(Model model, Vector2 position)
        {
            foreach (var modelEntry in model.Entries)
            {
                // GL.PushMatrix();
                // GL.LoadProjectionMatrix(Matrix4x4.Rotate(Quaternion.Euler(0, 0, modelEntry.Rotation)));
                Graphics.DrawTexture(new Rect(position+modelEntry.Offset, modelEntry.Size), modelEntry.Texture);
                // GL.PopMatrix();
            }
        }

        public record ModelEntry(Texture Texture, Vector2 Size, Vector2 Offset, float Rotation);
    }
}