using System.Collections.Generic;
using Game.Scripts.Render;
using UnityEngine;

namespace Game.Scripts.tile
{
    public class TileType
    {
        public readonly Model Model;
        public TileType(Model model)
        {
            Model = model;
        }
        private static readonly Shape HoverShape = new Shape(new Vector2(0, 0), new Vector2(6f, 0f), new Vector2(6f, 6f), new Vector2(0f, 6f));
        public virtual Shape GetHoverShape()
        {
            return HoverShape;
        }

        public RenderProvider GetRenderProvider()
        {
            throw new System.NotImplementedException();
        }
    }

}