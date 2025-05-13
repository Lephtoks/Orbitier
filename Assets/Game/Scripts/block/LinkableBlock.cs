using System.Collections.Generic;
using System.Collections.ObjectModel;
using Game.Scripts.block.link;
using Game.Scripts.items;
using Game.Scripts.Render;
using Game.Scripts.tile;
using Game.Scripts.World.Schedules;
using UnityEngine;

namespace Game.Scripts.block
{
    public abstract class LinkableBlock : Block
    {
        public readonly Dictionary<int, Link> Links = new Dictionary<int, Link>();
        
        private readonly List<LinkPoint> linkPoints = new List<LinkPoint>();
        
        private int _currentID = -1;

        protected LinkableBlock() : base()
        { }

        public int Link(LinkPoint from, LinkPoint to)
        {
            _currentID++;
            Links.Add(_currentID, new Link(from, to));
            return _currentID;
        }

        public bool CanBeLinked(LinkPoint from, LinkPoint to)
        {
            return from.Group == to.Group && from.Import && to.Export && from.CanBeLinked(to);
        }

        public virtual void Transfer(Link from)
        {
            
        }

        public ReadOnlyCollection<LinkPoint> GetLinkPoints()
        {
            return linkPoints.AsReadOnly();
        }
        protected void Send(Link link, ILinkItem linkItem)
        {
            var block = link.To.Owner;
            link.SetItem(linkItem);
            if (link.IsListening)
            {
                block.Transfer(link);
                link.IsListening = false;
            }
        }

        protected void OpenListener(float time)
        {
            OpenEternalListener();
            GetWorldMap().Schedules.Activate(new DelaySchedule(this, 0.5f, OnListenerExpire));
        }

        protected void OpenEternalListener()
        {
            foreach (var link in Links.Values)
            {
                link.IsListening = true;
            }
        }

        protected virtual void OnListenerExpire(ScheduleContainer container)
        {
            
        }

        protected void CloseListener()
        {
            foreach (var link in Links.Values)
            {
                link.IsListening = false;
            }
        }

        protected LinkPoint AddLinkPoint(LinkPoint linkPoint)
        {
            linkPoints.Add(linkPoint);
            return linkPoint;
        }
    }
}