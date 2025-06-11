#nullable enable
using System;
using Game.Scripts.Blocks;

namespace Game.Scripts.World.Schedules
{
    public abstract class CustomSchedule : Schedule
    {
        protected readonly Action<ScheduleContainer> Action;

        protected CustomSchedule(Block owner, Action<ScheduleContainer> action) : base(owner)
        {
            Action = action;
        }

        public override void Run()
        {
            Action.Invoke(Owner.GetWorldMap().Schedules);
        }
    }
}