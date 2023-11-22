
using KLO128.Calculator.Domain.Shared.Models.Expressions;

namespace KLO128.Calculator.Domain.Shared.Models
{
    /// <summary>
    /// Class that represents expression.
    /// </summary>
    public class ExpressionContextTree
    {
        /// <summary>
        /// Lexical Symbol of the expression. It should be null if this expression contains any <see cref="Children"/> that form the derivation of this non-leaf node in the tree.
        /// </summary>
        public Token? Token { get; set; }

        /// <summary>
        /// The derivation nodes of this nodes. If null, this expression is a leaf node with single <see cref="Token"/>.
        /// </summary>
        public LinkedList<ExpressionContextTree> Children { get; set; } = new LinkedList<ExpressionContextTree>();

        public Warning? Warning { get; set; }

        public ExpressionContextTree(Token Token)
        {
            this.Token = Token;
        }

        public ExpressionContextTree(Warning? warning)
        {
            Warning = warning;
        }

        public ExpressionContextTree(string errorCode, params string[] args)
        {
            Warning = new Warning(errorCode, args);
        }

        public ExpressionContextTree(BinaryExpression inner)
        {
            Warning = inner?.Warning ?? inner?.Appendix?.Inner?.Warning;
        }

        public ExpressionContextTree(AppendixExpression? appendix)
        {
            Warning = appendix?.Inner?.Warning ?? appendix?.Inner?.Appendix?.Inner?.Warning;
        }

        public override string ToString()
        {
            if (Token != null)
            {
                return Token.Text;
            }

            return string.Concat("Children: Count=", Children.Count);
        }
    }
}
