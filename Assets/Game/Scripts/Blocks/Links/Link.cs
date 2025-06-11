#nullable enable
using Game.Scripts.Items;
using Game.Scripts.World;
using UnityEngine;

namespace Game.Scripts.Blocks.Links
{
    public class Link
    {
        public readonly LinkPoint From;
        public readonly LinkPoint To;
        public Vector2 InterpolatedEnd;
        public readonly Color Color;
        public readonly LinkGroup Group;
        public readonly WorldMap? WorldMap;
        private ILinkItem? LinkItem;

        public Link(LinkPoint from, LinkPoint to, LinkGroup group = LinkGroup.OTHER, Color? color = null)
        {
            From = from;
            To = to;
            InterpolatedEnd = To.GetPos();
            Group = group;
            Color = color ??  Color.yellow;
            WorldMap = to.Owner.GetWorldMap();
        }

        public void ResetInterpolation()
        {
            InterpolatedEnd = From.GetPos();
        }

        ~Link()
        {
            SetItem(null);
        }

        public void SetItem(ILinkItem? linkItem)
        {
            LinkItem = linkItem;
            if (WorldMap == null) return;
            if (linkItem != null)
            {
                WorldMap.NotEmptyLinks.Add(this);
                return;
            }

            WorldMap.NotEmptyLinks.Remove(this);
        }

        public ILinkItem? GetItem()
        {
            return LinkItem;
        }

        public bool IsListening { get; set; } = false;
    }
}