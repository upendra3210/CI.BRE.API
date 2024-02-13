using System;
using System.Collections.Generic;

namespace CI.BRE.REPOSITERY.Entities
{
    public partial class SpsBrClassifier
    {
        public int Id { get; set; }
        public string? Dataset { get; set; }
        public int ClassifierId { get; set; }
    }
}
