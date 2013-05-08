using Decal.Adapter;
using Decal.Adapter.Wrappers;
using RantaTools;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DamageTracker
{
    public partial class PluginCore : PluginBase
    {
        static string MAGIC = "Magic";

        private Regex nonNumerics = new Regex(@"\D");
        private Regex meleeHit = new Regex(@"^(?<monster>[a-zA-Z' -]+) (?<verb>[a-zA-Z]+) your (?<area>[a-zA-Z ]+) for (?<points>[0-9]+) points? of (?<type>[a-zA-Z/' -]*)damage!");
        private Regex magicHit = new Regex(@"^(?<monster>[a-zA-Z' -]+) (?<verb>[a-zA-Z]+) you for (?<points>[0-9]+) points? with (?<type>[a-zA-Z/' -]*)");

        private SortedDictionary<string, HitStatisticGroup> sessionStats = new SortedDictionary<string, HitStatisticGroup>();

        void handleIncomingDamage(string msg, bool magic)
        {
            if (pluginSettings != null)
            {
                int d = 0;

                string m = nonNumerics.Replace(msg, string.Empty).Trim();
                if (Int32.TryParse(m, out d))
                {
                    Match match = null;
                    string area = magic ? MAGIC : DamageTypes.U;
                    if (magic && magicHit.IsMatch(msg))
                    {
                        match = magicHit.Match(msg);
                    }
                    else if (meleeHit.IsMatch(msg))
                    {
                        match = meleeHit.Match(msg);
                        area = match.Result("${area}");
                    }
                    if (match != null)
                    {
                        string type = DamageTypes.bestMatch(match.Result("${type}"));
                        d = Int32.Parse(match.Result("${points}"));

                        Hit h = new Hit(StringUtils.UCWords(area), type, d);

                        if (h.type == DamageTypes.U) pluginSettings.messages.Add(msg);

                        saveHit(h);
                        renderStats();
                    }
                }
            }

            // TODO: keep track of current health. on death, look at death message and add a hit for last-known-health+1
        }

        void saveHit(Hit h)
        {
            if (pluginSettings != null)
            {
                addHit(h, pluginSettings.stats);
            }
            addHit(h, sessionStats);
        }

        private void addHit(Hit h, SortedDictionary<string, HitStatisticGroup> d)
        {
            if (!d.ContainsKey(h.area))
            {
                d.Add(h.area, new HitStatisticGroup(h.area));
            }
            d[h.area].add(h);
        }
    }
}