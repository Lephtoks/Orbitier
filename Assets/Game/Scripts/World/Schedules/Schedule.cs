#nullable enable
using Game.Scripts.Blocks;

namespace Game.Scripts.World.Schedules
{
    public abstract class Schedule
    {
        public double Time;
        public readonly Block Owner;

        protected Schedule(Block owner)
        {
            Owner = owner;
        }
        public abstract double EstimatedTime(double time);

        public abstract void Run();

        public virtual void UponComplete(ScheduleContainer container)
        {
            container.Remove(this);
        }

    }
}