using UnityEngine;

namespace Game.Scripts.Data
{
    public record AnimatedTexture(float period, params TexturePart[] textures) : GameTexture
    {
        public TexturePart GetTexture()
        {
            return textures[(int)(Time.time/period % textures.Length)];
        }
    }
}