using System.Collections.Generic;
using Game.Scripts.Data;
using Game.Scripts.Registry;
using Game.Scripts.Render;
using Game.Scripts.Render.RenderProviders;
using UnityEngine;

namespace Game.Scripts.Tiling
{
    public class TileType : Registrable
    {
        protected Model Model;
        
        public void OnRegister(in Identifier item)
        {
            this.Model = OrbitierAssets.GetModel(Identifier.Of(item.getNamespace(), "tiles/" + item.getPath()));
        }
        private static readonly Shape HoverShape = new Shape(new Vector2(0, 0), new Vector2(6f, 0f), new Vector2(6f, 6f), new Vector2(0f, 6f));
        public virtual Shape GetHoverShape()
        {
            return HoverShape;
        }
        public RenderProvider GetRenderProvider(Tile tile)
        {
            return new ModelRenderProvider(Model, tile.GetPosition);
        }
    }

}