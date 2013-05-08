using System;
using System.Collections.Generic;
using System.Text;

namespace DamageTracker
{
    public interface IStatistic
    {
        string Name { get;  }

        long Count { get;  }
        double Average { get; }
        double Max { get; }
    }
}
