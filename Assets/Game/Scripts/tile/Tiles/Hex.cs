using Game.Scripts.Render;
using UnityEngine;

namespace Game.Scripts.tile.Tiles
{
    public class Hex : TileType
    {
        public Hex(Model model) : base(model) {}

        private static readonly Shape HoverShape = new Shape(new Vector2(0, 0), new Vector2(2f, 0f), new Vector2(4f, 2f), new Vector2(2f, 4f), new Vector2(0f, 4f), new Vector2(-2f, 2f));
        public override Shape GetHoverShape()
        {
            return HoverShape;
        }

        public static TileType Create(float x, float y, string texturePath, int xOffset, int yOffset)
        {
            return new Hex(
                Model.Of(Resources.Load<Texture>("Textures/Tiles/" + texturePath), new Vector2(x, y), new Vector2(xOffset, yOffset), 0)
            );
        }
        
    }
}