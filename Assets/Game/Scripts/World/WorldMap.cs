using System.Collections.Generic;
using System.Linq;
using Game.Scripts.block.link;
using Game.Scripts.Entity;
using Game.Scripts.tile;
using Game.Scripts.World.Schedules;

namespace Game.Scripts.World
{
    public class WorldMap
    {
        public readonly GameTileMap Map;
        private readonly Dictionary<string, LoadedEntity> _loadedEntities = new Dictionary<string, LoadedEntity>();
        public readonly ScheduleContainer Schedules = new();
        public readonly List<Link> NotEmptyLinks = new List<Link>();


        public WorldMap(GameTileMap map)
        {
            Map = map;
        }

        public void Update()
        {
            List<Schedule>? schedules = null;
            foreach (var schedule in Schedules.GetSchedules())
            {
                if (schedule.EstimatedTime(ScheduleManager.Time) <= 0)
                {
                    schedules ??= new List<Schedule>();
                    schedules.Add(schedule);
                    schedule.UponComplete(Schedules);
                }
            }

            if (schedules == null) return;
            
            foreach (var schedule1 in schedules.OrderBy(schedule => schedule.Time))
            {
                schedule1.Run();
            }

            foreach (var link in NotEmptyLinks)
            {
                link.SetItem(null);
            }
        }
    }
}