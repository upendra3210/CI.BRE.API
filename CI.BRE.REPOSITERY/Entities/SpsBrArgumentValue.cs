using System;
using System.Collections.Generic;

namespace CI.BRE.REPOSITERY.Entities
{
    public partial class SpsBrArgumentValue
    {
        public int BrKey { get; set; }
        public string? ProvinceState { get; set; }
        public string? ArgumentType { get; set; }
        public string? RuleType { get; set; }
        public string? Operator { get; set; }
        public string? TableName { get; set; }
        public string? ColumnName { get; set; }
        public string? ArgValue1 { get; set; }
        public string? ArgValue2 { get; set; }
        public string? UiRule { get; set; }
        public string? EtlRule { get; set; }
        public string? ErrorDescription { get; set; }
        public string? RowCreatedBy { get; set; }
        public DateTime? RowCreatedDate { get; set; }
        public string? RowChangedBy { get; set; }
        public DateTime? RowChangedDate { get; set; }
        public int? RunOrder { get; set; }
        public short? Severity { get; set; }
        public string RuleVersion { get; set; } = null!;
        public string Expression { get; set; } = null!;
        public string InputArgV2 { get; set; } = null!;
        public string ArgumentValue { get; set; } = null!;
        public bool IsBre2 { get; set; }
        public bool RuleRange { get; set; }

        public virtual SpsBrSeverity? SeverityNavigation { get; set; }
    }
    public partial class insertdata
    {
        public int BrKey { get; set; }
        public string? ProvinceState { get; set; }
        public string? ArgumentType { get; set; }
        public string? RuleType { get; set; }
        public string? Operator { get; set; }
        public string? TableName { get; set; }
        public string? ColumnName { get; set; }
        public string? ArgValue1 { get; set; }
        public string? ArgValue2 { get; set; }
        public string? UiRule { get; set; }
        public string? EtlRule { get; set; }
        public string? ErrorDescription { get; set; }
        public string? RowCreatedBy { get; set; }
        public DateTime? RowCreatedDate { get; set; }
        public string? RowChangedBy { get; set; }
        public DateTime? RowChangedDate { get; set; }
        public int? RunOrder { get; set; }
        public short? Severity { get; set; }
        public string RuleVersion { get; set; } = null!;
        public string Expression { get; set; } = null!;
        public string InputArgV2 { get; set; } = null!;
        public string ArgumentValue { get; set; } = null!;
        public bool IsBre2 { get; set; }
        public bool RuleRange { get; set; }

       
    }
}
