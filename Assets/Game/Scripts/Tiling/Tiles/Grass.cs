#nullable enable
using Game.Scripts.Render;
using UnityEngine;

namespace Game.Scripts.Tiling.Tiles
{
    public class Grass : TileType
    {
        private static readonly Shape HoverShape = new Shape(new Vector2(0, 0), new Vector2(6f, 0f), new Vector2(6f, 6f), new Vector2(0f, 6f));
        public override Shape GetHoverShape()
        {
            return HoverShape;
        }
        
    }
}