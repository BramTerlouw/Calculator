using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorUI
{
    class EmptyCalculator : IState
    {
        // -- fields
        frmCalculator calculator;

        // -- constructor
        public EmptyCalculator(frmCalculator calculator)
        {
            this.calculator = calculator;
        }
        
        /// <summary>
        /// -- this "state" represents the empty calculator state, no strategy or secundary input has been chosen yet. You enter your first
        /// -- number, then you choose a strategy (+, -, /, x, %, ^ or Root). When the strategy is chosen, the state is changed to "ChosenCalculation"
        /// </summary>

        // -- button behaviour
        public void Add()
        {
            calculator.a = float.Parse(calculator.display);
            calculator.strategy = new AddCalculation();
            calculator.calcState = new ChosenCalculation(calculator);
        }

        public void Divide()
        {
            calculator.a = float.Parse(calculator.display);
            calculator.strategy = new DivideCalculation();
            calculator.calcState = new ChosenCalculation(calculator);
        }

        public void Multiply()
        {
            calculator.a = float.Parse(calculator.display);
            calculator.strategy = new MultiplyCalculation();
            calculator.calcState = new ChosenCalculation(calculator);
        }

        public void Subtract()
        {
            calculator.a = float.Parse(calculator.display);
            calculator.strategy = new SubtractCalculation();
            calculator.calcState = new ChosenCalculation(calculator);
        }

        public void Modulo()
        {
            calculator.a = float.Parse(calculator.display);
            calculator.strategy = new ModuloCalculation();
            calculator.calcState = new ChosenCalculation(calculator);
        }

        public void Power()
        {
            calculator.a = float.Parse(calculator.display);
            calculator.strategy = new PowerCalculation();
            calculator.calcState = new ChosenCalculation(calculator);
        }




        // -- root behaviour
        public void Root()
        {
            calculator.strategy = new RootCalculation();
            calculator.calcState = new ChosenCalculation(calculator);
        }



        // -- equals behaviour
        public void Equals()
        {
            return;
        }
    }
}
