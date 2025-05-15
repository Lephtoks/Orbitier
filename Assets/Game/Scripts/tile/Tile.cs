using Game.Scripts.block;
using Game.Scripts.Render;
using Game.Scripts.World;
using UnityEngine;

namespace Game.Scripts.tile
{
    public class Tile : DrawableObject
    {
        private Vector2 _position;
        public readonly TileType TileType;
        protected WorldMap WorldMap;
        private Block _block;
        protected override RenderProvider RenderProvider => TileType.GetRenderProvider(this);

        public Tile(Vector2 position, TileType tileType)
        {
            _position = position;
            TileType = tileType;
        }

        public Vector2 GetPosition()
        {
            return _position;
        }

        public WorldMap GetWorldMap()
        {
            return WorldMap;
        }

        public void SetWorldMap(WorldMap worldMap)
        {
            WorldMap = worldMap;
        }

        public Block GetBlock()
        {
            return _block;
        }

        public void SetBlock(Block block)
        {
            _block = block;
            block.SetOwner(this);
        }
    }
}