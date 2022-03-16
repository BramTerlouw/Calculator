using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorUI
{
    class ChosenCalculation : IState
    {
        // -- fields
        frmCalculator calculator;

        // Constructor
        public ChosenCalculation(frmCalculator calculator)
        {
            this.calculator = calculator;
        }

        /// <summary>
        /// -- This state represents the "ChosenCalculation" state. When input a is entered and a strategy is chosen (+, -, /, x, %, ^ or Root) the calculator
        /// -- is changed to this state. Now the user can enter another value. When the used presses '=', the answer is shown and the state is changed to "FullCalculation".
        /// -- If the user enters a new value and presses a strategy (+, -, /, x, %, ^ or Root) again, the answer of the entered calculation is shown in the label of the
        /// -- display and assignd to the a value. The calculator stays in "ChosenCalculation" state and the user can enter a secundary value again.
        /// </summary>

        // -- Buttonbehaviour
        public void Add()
        {
            float answer = 0;
            if (calculator.strategy.GetType() == typeof(RootCalculation))
            {
                calculator.a = float.Parse(calculator.display);
                answer = calculator.strategy.PerformCalculation(calculator.a, 0);
                calculator.strategy = new AddCalculation();
                calculator.a = answer;
            }
            else
            {
                calculator.b = float.Parse(calculator.display);
                answer = calculator.strategy.PerformCalculation(calculator.a, calculator.b);
                calculator.strategy = new AddCalculation();
                calculator.a = answer;
            }
        }

        public void Divide()
        {
            float answer = 0;
            if (calculator.strategy.GetType() == typeof(RootCalculation))
            {
                calculator.a = float.Parse(calculator.display);
                answer = calculator.strategy.PerformCalculation(calculator.a, 0);
                calculator.strategy = new DivideCalculation();
                calculator.a = answer;
            }
            else
            {
                calculator.b = float.Parse(calculator.display);
                answer = calculator.strategy.PerformCalculation(calculator.a, calculator.b);
                calculator.strategy = new DivideCalculation();
                calculator.a = answer;
            }
        }

        public void Multiply()
        {
            float answer = 0;
            if (calculator.strategy.GetType() == typeof(RootCalculation))
            {
                calculator.a = float.Parse(calculator.display);
                answer = calculator.strategy.PerformCalculation(calculator.a, 0);
                calculator.strategy = new MultiplyCalculation();
                calculator.a = answer;
            }
            else
            {
                calculator.b = float.Parse(calculator.display);
                answer = calculator.strategy.PerformCalculation(calculator.a, calculator.b);
                calculator.strategy = new MultiplyCalculation();
                calculator.a = answer;
            }
        }

        public void Subtract()
        {
            float answer = 0;
            if (calculator.strategy.GetType() == typeof(RootCalculation))
            {
                calculator.a = float.Parse(calculator.display);
                answer = calculator.strategy.PerformCalculation(calculator.a, 0);
                calculator.strategy = new SubtractCalculation();
                calculator.a = answer;
            }
            else
            {
                calculator.b = float.Parse(calculator.display);
                answer = calculator.strategy.PerformCalculation(calculator.a, calculator.b);
                calculator.strategy = new SubtractCalculation();
                calculator.a = answer;
            }
        }

        public void Modulo()
        {
            float answer = 0;
            if (calculator.strategy.GetType() == typeof(RootCalculation))
            {
                calculator.a = float.Parse(calculator.display);
                answer = calculator.strategy.PerformCalculation(calculator.a, 0);
                calculator.strategy = new ModuloCalculation();
                calculator.a = answer;
            }
            else
            {
                calculator.b = float.Parse(calculator.display);
                answer = calculator.strategy.PerformCalculation(calculator.a, calculator.b);
                calculator.strategy = new ModuloCalculation();
                calculator.a = answer;
            }
        }

        public void Root()
        {
            float answer = 0;
            if (calculator.strategy.GetType() == typeof(RootCalculation))
            {
                calculator.a = float.Parse(calculator.display);
                answer = calculator.strategy.PerformCalculation(calculator.a, 0);
                calculator.SetLabelRoot(answer.ToString());

                calculator.strategy = new RootCalculation();
                calculator.calcState = new ChosenCalculation(calculator);
            }
            else
            {
                calculator.b = float.Parse(calculator.display);
                answer = calculator.strategy.PerformCalculation(calculator.a, calculator.b);
                calculator.strategy = new RootCalculation();
                calculator.SetLabelRoot(answer.ToString());
            }
        }

        public void Power()
        {
            float answer = 0;
            if (calculator.strategy.GetType() == typeof(RootCalculation))
            {
                calculator.a = float.Parse(calculator.display);
                answer = calculator.strategy.PerformCalculation(calculator.a, 0);
                calculator.strategy = new PowerCalculation();
                calculator.a = answer;
            }
            else
            {
                calculator.b = float.Parse(calculator.display);
                answer = calculator.strategy.PerformCalculation(calculator.a, calculator.b);
                calculator.strategy = new PowerCalculation();
                calculator.a = answer;
            }
        }



        // -- Equals behaviour
        public void Equals()
        {
            float answer = 0;
            if (calculator.strategy.GetType() == typeof(RootCalculation))
            {
                calculator.a = float.Parse(calculator.display);
                answer = calculator.strategy.PerformCalculation(calculator.a, 0);
                calculator.calcState = new FullCalculation(calculator);
                calculator.c = answer;
            }
            else
            {
                calculator.b = float.Parse(calculator.display);
                answer = calculator.strategy.PerformCalculation(calculator.a, calculator.b);
                calculator.calcState = new FullCalculation(calculator);
                calculator.c = answer;
            }
        }
    }
}
