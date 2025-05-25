using System;
using Game.Scripts.Blocks;

namespace Game.Scripts.World.Schedules
{
    public class LoopSchedule : CustomSchedule
    {
        private double _buildTime;
        private readonly float _cooldown;
        public override double EstimatedTime(double time)
        {
            return _buildTime + _cooldown - time;
        }

        public LoopSchedule(Block owner, float cooldown, Action<ScheduleContainer> action, double? buildTime=null, bool synchronized=false) : base(owner, action)
        {
            _buildTime = buildTime ?? ScheduleManager.Time;
            _buildTime = synchronized ? _buildTime : Math.Ceiling(_buildTime / cooldown) * cooldown;
            _cooldown = cooldown;
        }

        public override void UponComplete(ScheduleContainer container)
        {
            _buildTime += _cooldown;
        }
    }
}