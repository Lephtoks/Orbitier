using System;
using System.Collections.ObjectModel;
using Game.Scripts.block;
using Game.Scripts.block.link;
using UnityEngine;

namespace Game.Scripts.Render.renderProviders
{
    public class LinkableBlockRenderProvider : ModelRenderProvider
    {
        protected readonly ReadOnlyCollection<LinkPoint> links;

        public LinkableBlockRenderProvider(Model model, LinkableBlock block) : base(model, block.GetPosition)
        {
            this.links = block.GetLinkPoints();
        }

        public override void Render()
        {
            foreach (var link in links)
            {
                // Graphics.DrawTexture(new Rect(link.Point, new Vector2(1, 1)), );
            }
            base.Render();
        }
    }
}