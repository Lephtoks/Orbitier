using Game.Scripts.block.link;
using Game.Scripts.items;
using Game.Scripts.Render;
using Game.Scripts.Render.renderProviders;
using Game.Scripts.tile;
using Game.Scripts.tile.Tiles;
using Game.Scripts.World.Schedules;
using UnityEngine;

namespace Game.Scripts.block
{
    public class PulsarBlock : LinkableBlock
    {
        private readonly LinkPoint _linkPoint;

        protected override RenderProvider renderProvider => new ModelRenderProvider()

        public PulsarBlock() : base()
        {
            _linkPoint = AddLinkPoint(new LinkPoint(this, new Vector2(2, 2), LinkGroup.ENERGY, false, true));
        }

        public override void Init(ScheduleContainer container)
        {
            container.Activate(new LoopSchedule(this, 1, _ => Pulse(), synchronized: true));
        }

        public void Pulse()
        {
            if (_linkPoint.Link == null) return;
            
            Send(_linkPoint.Link, new Energy(10));
        }

        public override void Destroy(ScheduleContainer container)
        {
            container.RemoveAllOf(this);
        }

        private static readonly Model model = new Model(Resources.Load<Texture>("Textures/Tiles/square"),  new Vector2(4, 4), Vector2.zero);
    }
}