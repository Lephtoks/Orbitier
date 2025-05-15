using Game.Scripts.Registry;
using Game.Scripts.tile.Tiles;

namespace Game.Scripts.tile
{
    public static class GameTiles
    {
        public static void Init() {}
        private static readonly Registrar<TileType> R = Main.VANILLA.RegistrarOf(Registries.TILE_TYPE);
        
        public static readonly TileType SQUARE = R.Register("square", new TileType());
        public static readonly TileType HEX = R.Register("hex", new Hex());
    }
}