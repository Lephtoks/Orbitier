using Game.Scripts.Items;
using UnityEngine;

namespace Game.Scripts.Blocks.Links
{
    public class LinkPoint
    {
        public LinkableBlock Owner { get; }
        public Vector2 Point { get; }
        public bool Import { get; }
        public bool Export { get; }
        public LinkGroup Group { get; }
        public Link? Link { get; set; }

        public LinkPoint(LinkableBlock owner, Vector2 point, LinkGroup group, bool import = false, bool export = false)
        {
            Owner = owner;
            Point = point;
            Import = import;
            Export = export;
            Group = group;
        }

        public bool CanBeLinked(LinkPoint to)
        {
            return true;
        }

        public void SetItem(ILinkItem item)
        {
            Link?.SetItem(item);
        }

        public void LinkWIth(LinkPoint to)
        {
            var link = new Link(this, to, this.Group);
            this.Link = link;
            to.Link = link;
        }
    }
}