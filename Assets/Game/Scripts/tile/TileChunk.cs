using System.Collections.Generic;
using Game.Scripts.Render;
using Game.Scripts.tile.Mosaic;
using UnityEngine;

namespace Game.Scripts.tile
{
    public class TileChunk
    {
        private readonly Vector2 _position;
        private readonly Dictionary<Vector2, Tile> _tiles = new Dictionary<Vector2, Tile>();
        private readonly List<Tile> _updatableTiles = new List<Tile>();

        public const int SIZE = 6 * 16;
        public const float HALF_DIAGONAL = 3 * 16 * 1.414f; // sqrt(Size^2 * 2)/2

        public TileChunk(Vector2 position)
        {
            _position = position;
        }

        public void Generate()
        {
            _tiles.Clear();
            for (var x = 0; x < SIZE; x++)
            {
                for (var y = 0; y < SIZE; y++)
                {
                    var mosaic = Mosaics.HEX_HORIZONTAL;
                    var global = new Vector2(x, y) + _position * SIZE;
                    if (!mosaic.Check(global)) continue;
                    
                    var tile = mosaic.Generate(global);
                    AddTile(tile);
                    ObjectRenderer.ShowObject(tile);
                }
            }
        }

        public void AddTile(Tile tile)
        {
            _tiles.Add(ToLocal(tile.GetPosition()), tile);
        }

        public Tile GetTile(Vector2 sub)
        {
            return _tiles[sub];
        }

        public Vector2 GetPosition()
        {
            return _position;
        }

        public Vector2 GetCenterPosition()
        {
            return _position + new Vector2(SIZE, SIZE);
        }

        public static Vector2 ToLocal(Vector2 glob)
        {
            return new Vector2(glob.x % SIZE, glob.y % SIZE);
        }
        
    }
}