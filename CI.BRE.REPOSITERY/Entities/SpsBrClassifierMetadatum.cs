using System;
using System.Collections.Generic;

namespace CI.BRE.REPOSITERY.Entities
{
    public partial class SpsBrClassifierMetadatum
    {
        public int RelId { get; set; }
        public string? AttName { get; set; }
        public string? AttValue { get; set; }

        public virtual SpsBrClassifier Rel { get; set; } = null!;
    }
}
