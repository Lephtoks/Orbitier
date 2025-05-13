using System;
using Game.Scripts.block.link;
using Game.Scripts.tile;
using UnityEngine;

namespace Game.Scripts.block
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