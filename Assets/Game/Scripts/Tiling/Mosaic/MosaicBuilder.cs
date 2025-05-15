using System;
using UnityEngine;

namespace Game.Scripts.Tiling.Mosaic
{
    public class MosaicBuilder
    {
        private readonly Func<Vector2, bool> _predicate;
        private readonly Func<Vector2, Tile> _generator;

        public MosaicBuilder(Func<Vector2, bool> predicate, Func<Vector2, Tile> generator)
        {
            _predicate = predicate;
            _generator = generator;
        }

        public bool Check(int subX, int subY)
        {
            return Check(new Vector2(subX, subY));
        }

        public bool Check(Vector2 sub)
        {
            return _predicate.Invoke(sub);
        }

        public Tile Generate(int subX, int subY)
        {
            return Generate(new Vector2(subX, subY));
        }

        public Tile Generate(Vector2 sub)
        {
            return _generator.Invoke(sub);
        }

        public static bool DefaultPredicate(int x, int y)
        {
            return Repeating(x, y, 6, 6);
        }

        public static bool Repeating(int x, int y, int xr, int yr)
        {
            return x % xr == 0 && y % yr == 0;
        }

        public static bool Repeating(Vector2 sub, int xr, int yr)
        {
            return Repeating((int)sub.x, (int)sub.y, xr, yr);
        }

        public static bool DefaultPredicate(Vector2 sub)
        {
            return DefaultPredicate((int) sub.x, (int) sub.y);
        }
    }
}