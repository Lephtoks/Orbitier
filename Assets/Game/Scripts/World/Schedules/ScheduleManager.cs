using System;

namespace Game.Scripts.World.Schedules
{
    public static class ScheduleManager
    {
        public static double Time;
        public static Schedule CreateSchedule(Func<double, float, Schedule> factory, float delay)
        {
            return factory.Invoke(Time, delay);
        }

        public static Schedule CreateSynchronisedSchedule(Func<double, float, Schedule> factory, float delay)
        {
            return factory.Invoke(Math.Ceiling(Time / delay) * delay, delay);
        }
    }
}