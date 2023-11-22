namespace KLO128.Calculator.Domain.Shared.Models
{
    /// <summary>
    /// Lexical Symbol of expression
    /// </summary>
    public class Token
    {
        /// <summary>
        /// Token Text
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Index of the First <see cref="Token"/> Char
        /// </summary>
        public int StartCharIndex { get; set; }

        public int CharOrder => StartCharIndex + 1;

        public Token(string Text, int StartCharIndex = 0)
        {
            this.Text = Text;
            this.StartCharIndex = StartCharIndex;
        }

        /// <summary>
        /// Returns <see cref="Text"/>.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Text;
        }
    }
}
