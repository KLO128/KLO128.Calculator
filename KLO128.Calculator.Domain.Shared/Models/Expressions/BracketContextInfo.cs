using KLO128.Calculator.Domain.Shared;
using KLO128.Calculator.Domain.Shared.Models;

namespace KLO128.Calculator.Domain.Shared.Models.Expressions
{
    public class BracketContextInfo
    {
        public int BracketCount { get; set; }

        public int Order { get; set; }

        public BreakingToken BracketToken { get; set; } = null!;

        public OPStrength LowestOpStrength { get; set; } = Constants.HighestOPStrength;
    }
}
