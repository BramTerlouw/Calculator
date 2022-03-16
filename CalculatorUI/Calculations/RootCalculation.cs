using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorUI
{
    class RootCalculation : BaseCalculation
    {
        public override float PerformCalculation(float a, float b)
        {
            return (float)Math.Sqrt(a);
        }
    }
}
