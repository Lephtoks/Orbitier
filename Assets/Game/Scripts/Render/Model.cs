using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Render
{
    public class Model
    {
        private readonly List<ModelEntry> Entries;

        public Model(List<ModelEntry> entries)
        {
            this.Entries = entries;
        }

        public record ModelEntry(Texture Texture, Vector2 Size, Vector2 Offset, float Rotation);
    }
}