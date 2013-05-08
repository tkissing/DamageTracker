using System;
using System.Collections.Generic;
using System.Text;

namespace DamageTracker
{
    public class Hit
    {
        public string area;
        public string type;
        public int damage;
        
        public Hit(string area, string type, int damage)
        {
            this.area = area;
            this.type = type;
            this.damage = damage;
        }

        public Hit(string area, int damage) : this(area, DamageTypes.U, damage) { }
        public Hit(int damage) : this(DamageTypes.U, damage) { }
        public Hit() : this(0) { }
    }
}
