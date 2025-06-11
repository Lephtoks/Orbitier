#nullable enable
using Game.Scripts.Blocks.Links;
using Game.Scripts.Data;
using Game.Scripts.Items;
using Game.Scripts.Registry;
using Game.Scripts.Render;
using Game.Scripts.Render.RenderProviders;
using Game.Scripts.Tiling;
using Game.Scripts.Tiling.Tiles;
using Game.Scripts.World.Schedules;
using UnityEngine;

namespace Game.Scripts.Blocks
{
    public class PulsarBlock : LinkableBlock
    {
        private readonly LinkPoint _linkPoint;

        protected override RenderProvider RenderProvider => new LinkableBlockRenderProvider(model, this);

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
        private static readonly Model model = OrbitierAssets.GetModel(Identifier.OfVanilla("blocks/pulsar"));
    }
}