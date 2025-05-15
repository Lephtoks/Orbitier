namespace Game.Scripts.Tiling.Mosaic
{
    public static class Mosaics
    {
        public static readonly MosaicBuilder SQUARE = new MosaicBuilder(sub => sub.x % 6 == 0 && sub.y % 6 == 0, sub => new Tile(sub, GameTiles.SQUARE));

        public static readonly MosaicBuilder HEX_HORIZONTAL = new MosaicBuilder(
            sub => MosaicBuilder.Repeating(sub, 8, 4) || MosaicBuilder.Repeating((int)(sub.x + 4), (int)(sub.y + 2), 8, 4),
            sub => new Tile(sub, GameTiles.HEX));
    }
}