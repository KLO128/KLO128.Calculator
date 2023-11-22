using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLO128.Calculator.Domain.Shared.Models
{
    public enum OPStrength
    {
        LogicalOR,
        LogicalAnd,
        Comparison,
        Add,
        Multiple,
        Power
    }
}
