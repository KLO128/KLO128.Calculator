using KLO128.Calculator.Domain.Shared.Models;

namespace KLO128.Calculator.Domain.Shared.Models.Expressions
{
    public class BreakingToken
    {
        public Token Token { get; set; } = null!;
        public OP? Operator => Token as OP;

        public int BracketCount { get; set; }

        public int ContextBracketOrder { get; set; }

        public int EndBracketIndex { get; set; } = -1;

        public int TokenIndex { get; set; }

        public BreakingToken? NextOp { get; set; }

        public BreakingToken? LookAheadToken { get; set; }

        public bool IsMinusLeftBracket { get; set; }

        public BreakingToken? PrePreviousToken { get; set; }

        public BreakingToken(int TokenIndex)
        {
            this.TokenIndex = TokenIndex;
        }
    }
}
