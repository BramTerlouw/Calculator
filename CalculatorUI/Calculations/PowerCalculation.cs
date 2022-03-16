using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorUI
{
    class PowerCalculation : BaseCalculation
    {
        public override float PerformCalculation(float a, float b)
        {
            float answer = a;
            for (int i = 1; i < b; i++)
            {
                answer = answer * a;
            }
            return answer;
        }
    }
}
