namespace KLO128.Calculator.Infra.EFCore.SQLite.Db
{
    public partial class CalcEntry
    {
        public long CalcEntryId { get; set; }
        public long? CalcHistoryId { get; set; }
        public string Expression { get; set; } = null!;
        public double? Result { get; set; }
        public string? ErrorCode { get; set; }
        public string? ErrorArgs { get; set; }
        public string CreatedDate { get; set; } = null!;

        public virtual CalcHistory? CalcHistory { get; set; }
    }
}
