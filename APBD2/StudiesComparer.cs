using System;
using System.Collections.Generic;
using System.Text;

namespace APBD2
{
    public class StudiesComparer : IEqualityComparer<ActiveStudies>
    {

        public bool Equals(ActiveStudies x, ActiveStudies y)
        {
            return StringComparer
                .InvariantCultureIgnoreCase
                .Equals($"{x.name}",
                $"{y.name}");
        }
        public int GetHashCode(ActiveStudies obj)
        {
            return StringComparer
                .CurrentCultureIgnoreCase
                .GetHashCode($"{obj.name}");
        }
    }
}
