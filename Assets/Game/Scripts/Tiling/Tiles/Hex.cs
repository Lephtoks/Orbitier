#nullable enable
using Game.Scripts.Render;
using UnityEngine;

namespace Game.Scripts.Tiling.Tiles
{
    public class Hex : TileType
    {
        private static readonly Shape HoverShape = new Shape(new Vector2(0, 0), new Vector2(2f, 0f), new Vector2(4f, 2f), new Vector2(2f, 4f), new Vector2(0f, 4f), new Vector2(-2f, 2f));
        public override Shape GetHoverShape()
        {
            return HoverShape;
        }
        
    }
}