using System;
using System.Collections.Generic;
using System.Text;

namespace KLO128.Calculator.Domain.Shared.Models
{
    /// <summary>
    /// Operator of expression
    /// </summary>
    public class OP : Token, ICloneable
    {
        /// <summary>
        /// Operator Strength (Priority)
        /// </summary>
        public OPStrength Strength { get; set; }

        public OP(string Text, OPStrength Strength, int StartIndex = 0) : base(Text, StartIndex)
        {
            this.Strength = Strength;
        }

        public OP(string Text, int StartIndex = 0) : base(Text, StartIndex)
        {
            if (Constants.Operators.ContainsKey(Text))
            {
                Strength = Constants.Operators[Text].Strength;
            }
        }

        public object Clone()
        {
            return new OP(Text, Strength, StartCharIndex);
        }
    }
}
