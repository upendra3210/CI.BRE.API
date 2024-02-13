using System;
using System.Collections.Generic;

namespace CI.BRE.REPOSITERY.Entities
{
    public partial class SpsClassifierBrMapping
    {
        public int BrKey { get; set; }
        public int ClassifierId { get; set; }

        public virtual SpsBrArgumentValue BrKeyNavigation { get; set; } = null!;
    }
}
