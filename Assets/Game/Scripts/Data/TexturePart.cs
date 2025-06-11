using UnityEngine;

namespace Game.Scripts.Data
{
    public record TexturePart(int u, int v, int height, int width, Texture texture) : GameTexture
    {
        public TexturePart GetTexture()
        {
            return this;
        }
    }
}