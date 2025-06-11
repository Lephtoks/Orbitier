#nullable enable
using System;
using System.Collections.ObjectModel;
using Game.Scripts.Blocks;
using Game.Scripts.Blocks.Links;
using Game.Scripts.Data;
using Game.Scripts.Registry;
using UnityEngine;

namespace Game.Scripts.Render.RenderProviders
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