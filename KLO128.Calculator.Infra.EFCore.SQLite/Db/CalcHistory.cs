namespace KLO128.Calculator.Infra.EFCore.SQLite.Db
{
    public partial class CalcHistory
    {
        public CalcHistory()
        {
            CalcEntries = new HashSet<CalcEntry>();
        }

        public long CalcHistoryId { get; set; }
        public string Guid { get; set; } = null!;
        public string AccessToken { get; set; } = null!;
        public string? NameToDisplay { get; set; }
        public string CreatedDate { get; set; } = null!;
        public string UpdatedDate { get; set; } = null!;

        public virtual ICollection<CalcEntry> CalcEntries { get; set; }
    }
}
