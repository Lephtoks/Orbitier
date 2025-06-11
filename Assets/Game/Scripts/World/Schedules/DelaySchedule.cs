#nullable enable
using System;
using Game.Scripts.Blocks;

namespace Game.Scripts.World.Schedules
{
    public class DelaySchedule : CustomSchedule
    {
        private readonly double _buildTime;
        private readonly float _delay;

        public override double EstimatedTime(double time)
        {
            Time = _buildTime + _delay - time;
            return Time;
        }

        public DelaySchedule(Block owner, float delay, Action<ScheduleContainer> action, double? buildTime=null) : base(owner, action)
        {
            _buildTime = buildTime ?? ScheduleManager.Time;
            _delay = delay;
        }
    }
}