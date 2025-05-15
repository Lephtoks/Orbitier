using System;
using Game.Scripts.Blocks.Links;
using Game.Scripts.Tiling;
using UnityEngine;

namespace Game.Scripts.Blocks
{
    public class BaseBlock : LinkableBlock
    {
        private readonly LinkPoint In;

        public BaseBlock() : base()
        {
            In = AddLinkPoint(new LinkPoint(this, new Vector2(2, 2), LinkGroup.ITEM, true));
        }

        public override void Transfer(Link from)
        {
            Console.Out.WriteLine(from.GetItem());
        }
    }
}