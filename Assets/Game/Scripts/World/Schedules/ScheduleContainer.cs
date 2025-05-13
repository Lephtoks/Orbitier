using System.Collections.Generic;
using System.Linq;
using Game.Scripts.block;

namespace Game.Scripts.World.Schedules
{
    public class ScheduleContainer
    {
        private readonly List<Schedule> _schedules = new List<Schedule>();
        
        public void Remove(Schedule schedule)
        {
            _schedules.Remove(schedule);
        }
        public void RemoveAllOf(Block owner)
        {
            foreach (var schedule in _schedules.Where(schedule => schedule.Owner == owner))
            {
                Remove(schedule);
            }
        }

        public void Activate(Schedule schedule)
        {
            _schedules.Add(schedule);
        }

        public List<Schedule> GetSchedules()
        {
            return _schedules;
        }
    }
}