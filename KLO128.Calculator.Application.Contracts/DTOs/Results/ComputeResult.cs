using KLO128.Calculator.Domain.Shared.Models;

namespace KLO128.Calculator.Application.Contracts.DTOs.Results
{
    public class ComputeResult
    {
        public string Culture { get; set; } = null!;

        public bool UseSeparator { get; set; }

        public string Expression { get; set; } = null!;

        public string ExpressionNormalized { get; set; } = null!;

        public string? ResultToPrint { get; set; }

        public string ResultNormalized { get; set; } = null!;

        public double? Result { get; set; }

        public int ResultAsInteger { get; set; }

        public string? NewAccessToken { get; set; }

        public DateTime CreatedDate { get; set; }

        public Warning? Warning { get; set; }
    }
}
