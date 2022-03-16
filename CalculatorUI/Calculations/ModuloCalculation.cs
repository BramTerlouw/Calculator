using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorUI
{
    class ModuloCalculation : BaseCalculation
    {
        public override float PerformCalculation(float a, float b)
        {
            return a % b;
        }
    }
}
