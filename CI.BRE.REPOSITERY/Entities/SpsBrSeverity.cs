using System;
using System.Collections.Generic;

namespace CI.BRE.REPOSITERY.Entities
{
    public partial class SpsBrSeverity
    {
        public SpsBrSeverity()
        {
            SpsBrArgumentValues = new HashSet<SpsBrArgumentValue>();
        }

        public short Severity { get; set; }
        public string SeverityType { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual ICollection<SpsBrArgumentValue> SpsBrArgumentValues { get; set; }
    }
}
