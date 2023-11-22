using KLO128.Calculator.Application.Contracts.DTOs.Entities;

namespace KLO128.Calculator.Application.Contracts.DTOs.Results
{
    public class CalcHistoryResult
    {
        public List<Entry> EntriesToPrint { get; set; } = new List<Entry>();

        public int CalcHistoryId { get; set; }
        public string Guid { get; set; } = null!;
        public string AccessToken { get; set; } = null!;
        public string? NameToDisplay { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public ICollection<CalcEntryDTO>? CalcEntries { get; set; }

        public CalcHistoryResult(CalcHistoryDTO? calcHistoryDTO)
        {
            if (calcHistoryDTO == null)
            {
                return;
            }

            CalcHistoryId = calcHistoryDTO.CalcHistoryId;
            CalcEntries = calcHistoryDTO.CalcEntries;
            CreatedDate = calcHistoryDTO.CreatedDate;
            UpdatedDate = calcHistoryDTO.UpdatedDate;
            AccessToken = calcHistoryDTO.AccessToken;
            Guid = calcHistoryDTO.Guid;
            NameToDisplay = calcHistoryDTO.NameToDisplay;
        }

        public class Entry
        {
            private string? resultToPrint;
            public string? ResultToPrint { get => resultToPrint ?? Result?.ToString(); set => resultToPrint = value; }

            public int CalcEntryId { get; set; }
            public int? CalcHistoryId { get; set; }
            public string Expression { get; set; } = null!;
            public double? Result { get; set; }
            public string? ErrorCode { get; set; }
            public string? ErrorArgs { get; set; }
            public DateTime CreatedDate { get; set; }
            public CalcHistoryDTO? CalcHistory { get; set; }

            public Entry(CalcEntryDTO calcEntryDTO)
            {
                CalcEntryId = calcEntryDTO.CalcEntryId;
                CalcHistoryId = calcEntryDTO.CalcHistoryId;
                CalcHistory = calcEntryDTO.CalcHistory;
                Expression = calcEntryDTO.Expression;
                CreatedDate = calcEntryDTO.CreatedDate;
                ErrorCode = calcEntryDTO.ErrorCode;
                ErrorArgs = calcEntryDTO.ErrorArgs;
                Result = calcEntryDTO.Result;
            }
        }
    }
}
