using System;
using System.Collections.Generic;
using System.Text;

namespace DamageTracker
{
    public class HitStatistic : IStatistic
    {
        public double average;
        public long count;
        public long max;

        public double Average { get { return average; } }
        public long Count { get { return count; } }
        public double Max { get { return max; } }
        public string Name { get { return name; } }

        public string name;

        public HitStatistic()
        {
            reset();
        }

        public HitStatistic(string n) : this()
        {
            name = n;
        }

        public void add(Hit h)
        {
            average = (h.damage + count * average) / (count + 1);
            count = count + 1;
            max = Math.Max(max, h.damage);
        }

        public void reset()
        {
            average = 0;
            count = 0;
            max = 0;
        }

    }
}
