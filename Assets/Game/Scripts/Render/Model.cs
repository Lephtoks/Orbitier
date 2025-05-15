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

        public record ModelEntry(Texture Texture, Vector2 Size, Vector2 Offset, float Rotation);
    }
}