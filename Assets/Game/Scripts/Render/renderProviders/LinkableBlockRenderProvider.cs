using System;
using System.Collections.ObjectModel;
using Game.Scripts.block;
using Game.Scripts.block.link;
using Game.Scripts.data;
using Game.Scripts.Registry;
using UnityEngine;

namespace Game.Scripts.Render.renderProviders
{
    public class LinkableBlockRenderProvider : ModelRenderProvider
    {
        protected readonly ReadOnlyCollection<LinkPoint> links;
        private static readonly Model LINK_MODEL = OrbitierAssets.GetModel(Identifier.OfVanilla("blocks/special/link"));

        public LinkableBlockRenderProvider(Model model, LinkableBlock block) : base(model, block.GetPosition)
        {
            this.links = block.GetLinkPoints();
        }

        public override void Render()
        {
            base.Render();
            foreach (var link in links)
            {
                Model.RenderModel(LINK_MODEL, link.Point + this.positionProvider.Invoke());
            }
        }
    }
}