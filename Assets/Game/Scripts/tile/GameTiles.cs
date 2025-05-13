using Game.Scripts.Registry;
using Game.Scripts.tile.Tiles;

namespace Game.Scripts.tile
{
    public static class GameTiles
    {
        public static void Init() {}
        private static readonly Registrar<TileType> R = Main.VANILLA.RegistrarOf(Registries.TILE_TYPE);
        
        public static readonly TileType SQUARE = R.Register("square", TileType.Create(6f, 6f, "square", 0, 0));
        public static readonly TileType HEX = R.Register("hex", Hex.Create(6f, 6f, "hex", -2, -1));
    }
}