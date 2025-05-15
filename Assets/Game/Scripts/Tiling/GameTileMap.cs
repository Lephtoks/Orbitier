using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Tiling
{
    public class GameTileMap
    {
        private readonly Dictionary<Vector2, TileChunk> _tileChunks = new Dictionary<Vector2, TileChunk>();

        public void AddTile(Tile tile)
        {
            var chunkPos = ToChunkPos(tile.GetPosition());
            var chunk = GetOrGenerateEmptyChunk(chunkPos);
            chunk.AddTile(tile);
        }

        public Tile GetTile(Vector2 pos)
        {
            return GetChunk(ToChunkPos(pos)).GetTile(pos);
        }

        public TileChunk GenerateChunk(Vector2 pos)
        {
            var chunk = new TileChunk(pos);
            chunk.Generate();
            return chunk;
        }

        public TileChunk GetChunk(Vector2 pos)
        {
            return _tileChunks[pos];
        }

        public TileChunk GetOrGenerateChunk(Vector2 pos)
        {
            var chunk = _tileChunks.GetValueOrDefault(pos);
            if (chunk is null)
            {
                chunk = GenerateChunk(pos); 
            }

            return chunk;
        }

        private TileChunk GetOrGenerateEmptyChunk(Vector2 pos)
        {
            var chunk = _tileChunks.GetValueOrDefault(pos);
            if (chunk is null)
            {
                chunk = new TileChunk(pos); 
            }

            return chunk;
        }

        public static Vector2 ToChunkPos(Vector2 glob)
        {
            return new Vector2(Mathf.FloorToInt(glob.x) / TileChunk.SIZE,
                Mathf.FloorToInt(glob.y) / TileChunk.SIZE);
        }
    }
}