
///
/// generated file 26.10.2023 18:46:41
///

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KLO128.Calculator.Application.Contracts.DTOs.Entities
{
    public class CalcHistoryDTO
    {

        public int CalcHistoryId { get; set; }
        public string Guid { get; set; } = null!;
        public string AccessToken { get; set; } = null!;
        public string? NameToDisplay { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        private ICollection<CalcEntryDTO>? calcEntries;
        public ICollection<CalcEntryDTO> CalcEntries
        {
            get
            {
                if (calcEntries == null)
                {
                    calcEntries = new List<CalcEntryDTO>();
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
