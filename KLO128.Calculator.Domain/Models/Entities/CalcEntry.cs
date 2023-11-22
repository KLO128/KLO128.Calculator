
///
/// generated file
///

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KLO128.Calculator.Domain.Models.Entities
{
    public class CalcEntry
    {

        
        public int CalcEntryId { get; set; }
        
        public int? CalcHistoryId { get; set; }
        
        public string Expression { get; set; } = null!;
        
        public double? Result { get; set; }
        
        public string? ErrorCode { get; set; }
        
        public string? ErrorArgs { get; set; }
        
        public DateTime CreatedDate { get; set; }
        
        public CalcHistory? CalcHistory { get; set; }
    }
}