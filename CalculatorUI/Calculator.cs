using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorUI
{
    public partial class frmCalculator : Form
    {
        // fields / properties
        public float a, b, c;
        public string display;
        public IState calcState;
        public BaseCalculation strategy;
        public int commaCount;

        // constructor
        public frmCalculator()
        {
            InitializeComponent();
            a = b = c = 0;
            display = "";
            calcState = new EmptyCalculator(this);
            strategy = null;
            commaCount = 0;
        }






        // -- Buttons for all the numbers
        // -- When a button is pressed, a function is called to perform the action (prevent duplicate code)
        private void btnZero_Click(object sender, EventArgs e)  {NumberBehaviour(0);}
        private void btnOne_Click(object sender, EventArgs e)   {NumberBehaviour(1);}
        private void btnTwo_Click(object sender, EventArgs e)   {NumberBehaviour(2);}
        private void btnThree_Click(object sender, EventArgs e) {NumberBehaviour(3);}
        private void btnFour_Click(object sender, EventArgs e)  {NumberBehaviour(4);}
        private void btnFive_Click(object sender, EventArgs e)  {NumberBehaviour(5);}
        private void btnSix_Click(object sender, EventArgs e)   {NumberBehaviour(6);}
        private void btnSeven_Click(object sender, EventArgs e) {NumberBehaviour(7);}
        private void btnEight_Click(object sender, EventArgs e) {NumberBehaviour(8);}
        private void btnNine_Click(object sender, EventArgs e)  {NumberBehaviour(9);}
        
        // -- When the state is "FullCalculation", the calculator resets when a number is pressed
        // -- It then adds a number to the end of the display
        private void NumberBehaviour(int number)
        {
            if (calcState.GetType() == typeof(FullCalculation))
            {
                calcState = new EmptyCalculator(this);
                strategy = null;
                display = "";
                lblPlaceholder.Text = "____";
            }
            display += number.ToString();
            txtCalcDisplay.Text = display;
        }







        // -- Buttons for all strategies / calculations
        // -- When a "strategy" button is pressed, a function is called to perform the action (prevent duplicate code)
        private void btnPower_Click(object sender, EventArgs e)        {StrategyBehaviour("Power");}
        private void btnModulo_Click(object sender, EventArgs e)      {StrategyBehaviour("Modulo");}
        private void btnDivide_Click(object sender, EventArgs e)      {StrategyBehaviour("Divide");}
        private void btnMultiply_Click(object sender, EventArgs e)  {StrategyBehaviour("Multiply");}
        private void btnAdd_Click(object sender, EventArgs e)          { StrategyBehaviour("Add"); }
        
        // -- when no number has been entered yet and the minus button gets pressed on, the number entered next will be negative
        // -- otherwise the subtract strategy is chosen
        private void btnSubtract_Click(object sender, EventArgs e)  
        {
            if (display != "")
            {
                calcState.Subtract();
                txtCalcDisplay.Text = "-";
                display = "";
                lblPlaceholder.Text = a.ToString();
                commaCount = 0;
            }
            else
            {
                display += "-";
                txtCalcDisplay.Text = display;
            }
        }

        // -- this method performs the chosen strategy actions based on the state of the calculator
        // -- The parameter is a string with a description of the strategy, a switch determines the action based on this string
        private void StrategyBehaviour(string strategy)
        {
            if (display != "") 
            {
                switch (strategy)
                {
                    case "Add":
                        calcState.Add();
                        txtCalcDisplay.Text = "+";
                        break;
                    case "Multiply":
                        calcState.Multiply();
                        txtCalcDisplay.Text = "x";
                        break;
                    case "Divide":
                        calcState.Divide();
                        txtCalcDisplay.Text = "/";
                        break;
                    case "Power":
                        calcState.Power();
                        txtCalcDisplay.Text = "^";
                        break;
                    case "Modulo":
                        calcState.Modulo();
                        txtCalcDisplay.Text = "%";
                        break;
                    default:
                        break;
                }
                display = "";
                lblPlaceholder.Text = a.ToString();
                commaCount = 0;
            }
        }






        // -- Root section
        // -- When the button for root is pressed, it performs the action below
        private void btnRoot_Click(object sender, EventArgs e)
        {
            if (strategy == null || strategy.GetType() == typeof(RootCalculation) || calcState.GetType() == typeof(FullCalculation))
            {
                txtCalcDisplay.Text = "√";
                calcState.Root();
                display = "";
            }
        }
        // -- places the answer of the calculation on the private label of the calculator (used in other file) without making te label public (bad practise)
        public void SetLabelRoot(string number) {lblPlaceholder.Text = number;}







        // -- Buttons for all functions
        // -- When the button '=' is pressed, this method performs the action depending on the state and fills the txtbox and label
        private void btnEquals_Click(object sender, EventArgs e)
        {
            if (display != "")
            {
                calcState.Equals();
                txtCalcDisplay.Text = c.ToString();
                lblPlaceholder.Text = c.ToString();
            }
        }

        // -- When the count of comma's is 0 and this button is pressed, it places a ',' on the display and increases the commacount by 1
        private void btnDot_Click(object sender, EventArgs e)
        {
            if (commaCount == 0)
            {
                display += ",";
                txtCalcDisplay.Text = display;
                commaCount++;
            }
        }

        // -- When there are numbers on the display and this button is pressed, it removes the last number
        private void btnBackspace_Click(object sender, EventArgs e)
        {
            if ( display.Length > 0)
            {
                if (display[display.Length - 1].ToString() == ",")
                    commaCount = 0;

                display = display.Remove(display.Length - 1, 1);
                txtCalcDisplay.Text = display;
            }
        }

        // -- Cleares and resets everything
        private void btnC_Click(object sender, EventArgs e)
        {
            a = b = c = commaCount = 0;
            display = "";
            calcState = new EmptyCalculator(this);
            strategy = null;
            lblPlaceholder.Text = "____";
            txtCalcDisplay.Text = "";
        }

        // -- Cleares the latest input but not the calculation
        private void btnCA_Click(object sender, EventArgs e)
        {
            display = "";
            txtCalcDisplay.Text = display;
            commaCount = 0;
        }
    }
}
