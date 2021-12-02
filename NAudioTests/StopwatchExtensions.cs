﻿using System;
using System.Diagnostics;
using System.Linq;

namespace NAudioTests
{
    public static class StopwatchExtensions
    {
        public static long Time(this Stopwatch sw, Action action, int iterations)
        {
            sw.Reset();
            sw.Start();
            for (int i = 0; i < iterations; i++)
            {
                action();
            }
            sw.Stop();

            return sw.ElapsedMilliseconds;
        }

        public static long Time(this Stopwatch sw, Action action)
        {
            return Time(sw, action, 1);
        }
    }
}
