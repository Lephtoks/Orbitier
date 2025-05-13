using Game.Scripts.Render;
using Game.Scripts.tile;
using Game.Scripts.World;
using Game.Scripts.World.Schedules;
using UnityEngine;

namespace Game.Scripts.block
{
    public abstract class Block : IModelOwner
    {
        protected WorldMap? WorldMap;
        private Tile RootTile;
        protected Block()
        {
        }
        public virtual void Init(ScheduleContainer container) {}
        public virtual void Destroy(ScheduleContainer container) {}

        public void SetWorldMap(WorldMap worldMap)
        {
            WorldMap = worldMap;
        }

        public WorldMap? GetWorldMap()
        {
            return WorldMap;
        }

        public void SetOwner(Tile tile)
        {
            RootTile = tile;
        }

        public Tile GetOwner()
        {
            return RootTile;
        }

        public virtual Model GetModel()
        {
            return null;
        }

        public Vector2 GetModelPosition()
        {
            return GetPosition();
        }

        public virtual Vector2 GetPosition()
        {
            return this.GetOwner().GetPosition();
        }

        protected virtual void RenderThis()
        {
            ((IDrawableObject) this).Render();
        }
    }
}