using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorUI
{
    class FullCalculation : IState
    {
        // -- fields
        frmCalculator calculator;

        // -- constructor
        public FullCalculation(frmCalculator calculator)
        {
            this.calculator = calculator;
        }

        /// <summary>
        /// -- This state represents the "FullCalculation" state. This state is entered when a user finishes a calculation by pressing '='. From here
        /// -- the user can choose to press a strategy (+, -, /, x, %, ^ or Root) to continue the calculation or press a number to start a whole new calculation.
        /// </summary>

        // -- button behaviour
        public void Add()
        {
            calculator.a = calculator.c;
            calculator.strategy = new AddCalculation();
            calculator.calcState = new ChosenCalculation(calculator);
        }

        public void Divide()
        {
            calculator.a = calculator.c;
            calculator.strategy = new DivideCalculation();
            calculator.calcState = new ChosenCalculation(calculator);
        }

        public void Multiply()
        {
            calculator.a = calculator.c;
            calculator.strategy = new MultiplyCalculation();
            calculator.calcState = new ChosenCalculation(calculator);
        }

        public void Subtract()
        {
            calculator.a = calculator.c;
            calculator.strategy = new SubtractCalculation();
            calculator.calcState = new ChosenCalculation(calculator);
        }

        public void Modulo()
        {
            calculator.a = calculator.c;
            calculator.strategy = new ModuloCalculation();
            calculator.calcState = new ChosenCalculation(calculator);
        }

        public void Power()
        {
            calculator.a = calculator.c;
            calculator.strategy = new PowerCalculation();
            calculator.calcState = new ChosenCalculation(calculator);
        }




        // -- Root behaviour
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
