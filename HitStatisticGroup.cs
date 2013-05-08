using System;
using System.Collections.Generic;
using System.Text;

namespace DamageTracker
{
    public class HitStatisticGroup : IStatistic
    {
        public string name;

        public HitStatistic bludg;
        public HitStatistic pierce;
        public HitStatistic slash;

        public HitStatistic acid;
        public HitStatistic fire;
        public HitStatistic frost;
        public HitStatistic light;

        public HitStatistic drain;
        public HitStatistic hollow;
        public HitStatistic nether;        
        public HitStatistic unknown;

        public Dictionary<string, HitStatistic>.Enumerator GetEnumerator() { return lkp.GetEnumerator(); }

        [System.Xml.Serialization.XmlIgnoreAttribute]
        public double Average { get { return average; } }
        [System.Xml.Serialization.XmlIgnoreAttribute]
        public long Count { get { return count; } }
        [System.Xml.Serialization.XmlIgnoreAttribute]
        public double Max { get { return max; } }
        [System.Xml.Serialization.XmlIgnoreAttribute]
        public string Name { get { return name; } }

        public HitStatisticGroup()
        {
            bludg = new HitStatistic(DamageTypes.B);
            pierce = new HitStatistic(DamageTypes.P);
            slash = new HitStatistic(DamageTypes.S);

            acid = new HitStatistic(DamageTypes.A);
            fire = new HitStatistic(DamageTypes.F);
            frost = new HitStatistic(DamageTypes.C);
            light = new HitStatistic(DamageTypes.L);

            drain = new HitStatistic(DamageTypes.D);
            hollow = new HitStatistic(DamageTypes.H);
            nether = new HitStatistic(DamageTypes.N);
            unknown = new HitStatistic(DamageTypes.U);
        }

        public HitStatisticGroup(string n) : this()
        {
            name = n;
        }

        public IStatistic Filtered(string damage)
        {
            Dictionary<string, HitStatistic> d = lkp;
            if (d.ContainsKey(damage))
            {
                HitStatistic s = new HitStatistic(name);
                s.average = d[damage].average;
                s.count = d[damage].count;
                s.max = d[damage].max;
                return s;
            }

            return this;
        }

        public void add(Hit h)
        {
            Dictionary<string, HitStatistic> d = lkp;
            if (d.ContainsKey(h.type)) d[h.type].add(h);
            else unknown.add(h);
        }

        [System.Xml.Serialization.XmlIgnoreAttribute]
        protected Dictionary<string, HitStatistic> lkp
        {
            get
            {
                Dictionary<string, HitStatistic> d = new Dictionary<string, HitStatistic>();
                d.Add(DamageTypes.B, bludg);
                d.Add(DamageTypes.P, pierce);
                d.Add(DamageTypes.S, slash);

                d.Add(DamageTypes.A, acid);
                d.Add(DamageTypes.C, frost);
                d.Add(DamageTypes.F, fire);
                d.Add(DamageTypes.L, light);

                d.Add(DamageTypes.D, drain);
                d.Add(DamageTypes.H, hollow);
                d.Add(DamageTypes.N, nether);
                d.Add(DamageTypes.U, unknown);

                return d;
            }
        }

        public void reset()
        {
            bludg.reset();
            pierce.reset();
            slash.reset();

            acid.reset();
            frost.reset();
            fire.reset();
            light.reset();

            drain.reset();
            hollow.reset();
            nether.reset();
            unknown.reset();
        }

        public double average
        {
            get
            {
                if (count == 0) return 0;

                double s = bludg.average * bludg.count
                    + pierce.average * pierce.count
                    + slash.average * slash.count
                    + acid.average * acid.count
                    + fire.average * fire.count
                    + frost.average * frost.count
                    + light.average * light.count
                    + drain.average * drain.count
                    + hollow.average * hollow.count
                    + nether.average * nether.count                    
                    + unknown.average * unknown.count;
                return s / count;
            }
        }

        public long count
        {
            get
            {
                return bludg.count + pierce.count + slash.count
                    + acid.count + fire.count + frost.count + light.count
                    + drain.count + hollow.count + nether.count + unknown.count;
            }
        }

        public long max { get { return Maximum(bludg.max, pierce.max, slash.max, acid.max, fire.max, frost.max, light.max,
            drain.max, hollow.max, nether.max, unknown.max); } }

        private long Maximum(params long[] values)
        {
            if (values.Length == 0) return 0;
            if (values.Length == 1) return values[0];
            if (values.Length == 2) return Math.Max(values[0], values[1]);
            if (values.Length == 3) return Math.Max(values[0], Math.Max(values[1], values[2]));
            if (values.Length == 4) return Math.Max(values[0], Math.Max(values[1], Math.Max(values[2], values[3])));

            List<long> v = new List<long>(values);
            return Math.Max(Maximum(v.GetRange(0, 4).ToArray()), Maximum(v.GetRange(4, v.Count - 4).ToArray()));
        }
    }
}
