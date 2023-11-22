
///
/// generated file 26.10.2023 18:46:41
///

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KLO128.Calculator.Application.Contracts.DTOs.Entities
{
    public class CalcEntryDTO
    {

        public int CalcEntryId { get; set; }
        public int? CalcHistoryId { get; set; }
        public string Expression { get; set; } = null!;
        public double? Result { get; set; }
        public string? ErrorCode { get; set; }
        public string? ErrorArgs { get; set; }
        public DateTime CreatedDate { get; set; }
        public CalcHistoryDTO? CalcHistory { get; set; }
    }
}
