using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DamageTracker
{
    public static class DamageTypes
    {
        public static string B = "Bludgeoning";
        public static string P = "Piercing";
        public static string S = "Slashing";

        public static string A = "Acid";
        public static string C = "Cold";
        public static string F = "Fire";
        public static string L = "Lightning";

        public static string D = "Drain";
        public static string N = "Nether";
        public static string H = "Untyped"; // untyped, hollow damage
        public static string U = "Unknown";

        public static Regex rB = new Regex(@"(bludgeoning|fusillade|pummeling storm|thousand fists|cameron's curse|crushing shame|shock|hammering crawler|tectonic rifts)");
        public static Regex rP = new Regex(@"(piercing|stinging needles|outlander's insolence|the spike|force|spike strafe|nuhmudira's spines)");
        public static Regex rS = new Regex(@"(slashing|blade|sau kolin's sword|flensing wings|rending wind|evisceration|bed of blades|horizon's blades)");

        public static Regex rA = new Regex(@"(acid|disintegration|corrosive flash|celdiseth's searing|dissolving vortex|blistering creeper|searing disc)");
        public static Regex rC = new Regex(@"(cold|frost|icy torment|blizzard|winter's embrace|foon-ki's glacial floe|halo of frost)");
        public static Regex rF = new Regex(@"(flame|fire|ilservian's flame|sizzling fury|infernae|silencia's scorn|slithering flames|cassius' ring of fire)");
        public static Regex rL = new Regex(@"(lightning|alset's coil|lhen's flare|luminous wrath|tempest|os' wall|eye of the storm)");

        public static Regex rD = new Regex(@"(harm|smite|death|grael's rage|tormenter of flesh|martyr's hetacomb|raider tag|curse of raven fury|blood bolt|heart rend|poison|mucor bolt|mucor jolt|dissolution|kivik lir's scorn)");
        public static Regex rN = new Regex(@"(nether|corrosion|corruption|clouded soul)");
        public static Regex rH = new Regex(@" points of damage");

        public static string bestMatch(string s)
        {
            if (s == null || s.Trim().Equals(string.Empty)) return H;

			string ls = s.ToLower();
			
            if (rB.IsMatch(ls)) return B;
            if (rP.IsMatch(ls)) return P;
            if (rS.IsMatch(ls)) return S;

            if (rA.IsMatch(ls)) return A;
            if (rC.IsMatch(ls)) return C;
            if (rF.IsMatch(ls)) return F;
            if (rL.IsMatch(ls)) return L;

            if (rD.IsMatch(ls)) return D;
            if (rN.IsMatch(ls)) return N;
            if (rH.IsMatch(ls)) return H;

            return U;
        }
    }
}
