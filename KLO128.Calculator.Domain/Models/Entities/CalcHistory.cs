
///
/// generated file
///

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KLO128.Calculator.Domain.Models.Entities
{
    public class CalcHistory
    {

        
        public int CalcHistoryId { get; set; }
        
        public string Guid { get; set; } = null!;
        
        public string AccessToken { get; set; } = null!;
        
        public string? NameToDisplay { get; set; }
        
        public DateTime CreatedDate { get; set; }
        
        public DateTime UpdatedDate { get; set; }
        private ICollection<CalcEntry>? calcEntries;
        public ICollection<CalcEntry> CalcEntries
        {
            get
            {
                if (calcEntries == null)
                {
                    calcEntries = new List<CalcEntry>();
                }

                return calcEntries;
            }
            set
            {
                calcEntries = value;
            }
        }

    }
}