using Game.Scripts.Items;
using Game.Scripts.World;

namespace Game.Scripts.Blocks.Links
{
    public class Link
    {
        public readonly LinkPoint From;
        public readonly LinkPoint To;
        public readonly int Color;
        public readonly LinkGroup Group;
        public readonly WorldMap? WorldMap;
        private ILinkItem? LinkItem;

        public Link(LinkPoint from, LinkPoint to, LinkGroup group = LinkGroup.OTHER, int color = -1)
        {
            From = from;
            To = to;
            Group = group;
            Color = color;
            WorldMap = to.Owner.GetWorldMap();
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