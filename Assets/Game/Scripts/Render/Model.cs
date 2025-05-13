using UnityEngine;

namespace Game.Scripts.Render
{
    public class Model
    {
        public readonly Texture Texture;
        public readonly Vector2 Size;
        public readonly Vector2 Offset;

        public Model(Texture texture, Vector2 size, Vector2 offset)
        {
            Texture = texture;
            Size = size;
            Offset = offset;
        }

        public static Model Of(string texturePath, int x, int y, int xOffset, int yOffset)
        {
            return new Model(Resources.Load<Texture>("Textures/" + texturePath), new Vector2(x, y),
                new Vector2(xOffset, yOffset));

        }
    }
}