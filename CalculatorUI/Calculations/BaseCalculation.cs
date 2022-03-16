using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorUI
{
    public abstract class BaseCalculation
    {
        // -- This class is the base class for all calculations
        // -- All calculation classes override the method below for their calculations
        public abstract float PerformCalculation(float a, float b);
    }
}
