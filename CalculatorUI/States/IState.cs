using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorUI
{
    public interface IState
    {
        // -- button behaviour
        // -- This is the interface for the calculations and the equal(=) button
        public void Subtract();
        public void Add();
        public void Multiply();
        public void Divide();
        public void Modulo();
        public void Root();
        public void Power();

        // -- functions
        public void Equals();
    }
}
