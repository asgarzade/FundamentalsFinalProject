using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        double FirstNumber = 0.0;
        double SecondNumber = 0.0;
        char Operator;
        double Result;
        bool operationCompleted = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void zeroButton_Click(object sender, EventArgs e)
        {
            if (operationCompleted)
            {
                displayLabel.Text = String.Empty;
                displayBox.Text = String.Empty;
                operationCompleted = false;
            }

            if (displayBox.Text == "0")
            {
                displayBox.Text = "0";
            }
            else
            {
                displayBox.Text += 0;
            }
        }

        private void oneButton_Click(object sender, EventArgs e)
        {
            if (operationCompleted)
            {
                displayLabel.Text = String.Empty;
                displayBox.Text = String.Empty;
                operationCompleted = false;
            }

            if (displayBox.Text == "0")
            {
                displayBox.Text = "1";
            }
            else
            {
                displayBox.Text += 1;
            }
        }    

        private void twoButton_Click(object sender, EventArgs e)
        {
            if (operationCompleted)
            {
                displayLabel.Text = String.Empty;
                displayBox.Text = String.Empty;
                operationCompleted = false;
            }

            if (displayBox.Text == "0")
            {
                displayBox.Text = "2";
            }
            else
            {
                displayBox.Text += 2;
            }
        }

        private void threeButton_Click(object sender, EventArgs e)
        {
            if (operationCompleted)
            {
                displayLabel.Text = String.Empty;
                displayBox.Text = String.Empty;
                operationCompleted = false;
            }

            if (displayBox.Text == "0")
            {
                displayBox.Text = "3";
            }
            else
            {
                displayBox.Text += 3;
            }
        }
        
        private void fourButton_Click(object sender, EventArgs e)
        {
            if (operationCompleted)
            {
                displayLabel.Text = String.Empty;
                displayBox.Text = String.Empty;
                operationCompleted = false;
            }

            if (displayBox.Text == "0")
            {
                displayBox.Text = "4";
            }
            else
            {
                displayBox.Text += 4;
            }
        }

        private void fiveButton_Click(object sender, EventArgs e)
        {
            if (operationCompleted)
            {
                displayLabel.Text = String.Empty;
                displayBox.Text = String.Empty;
                operationCompleted = false;
            }

            if (displayBox.Text == "0")
            {
                displayBox.Text = "5";
            }
            else
            {
                displayBox.Text += 5;
            }
        }

        private void sixButton_Click(object sender, EventArgs e)
        {
            if (operationCompleted)
            {
                displayLabel.Text = String.Empty;
                displayBox.Text = String.Empty;
                operationCompleted = false;
            }

            if (displayBox.Text == "0")
            {
                displayBox.Text = "6";
            }
            else
            {
                displayBox.Text += 6;
            }
        }

        private void sevenButton_Click(object sender, EventArgs e)
        {
            if (operationCompleted)
            {
                displayLabel.Text = String.Empty;
                displayBox.Text = String.Empty;
                operationCompleted = false;
            }

            if (displayBox.Text == "0")
            {
                displayBox.Text = "7";
            }
            else
            {
                displayBox.Text += 7;
            }
        }

        private void eightButton_Click(object sender, EventArgs e)
        {
            if (operationCompleted)
            {
                displayLabel.Text = String.Empty;
                displayBox.Text = String.Empty;
                operationCompleted = false;
            }

            if (displayBox.Text == "0")
            {
                displayBox.Text = "8";
            }
            else
            {
                displayBox.Text += 8;
            }
        }

        private void nineButton_Click(object sender, EventArgs e)
        {
            if (operationCompleted)
            {
                displayLabel.Text = String.Empty;
                displayBox.Text = String.Empty;
                operationCompleted = false;
            }

            if (displayBox.Text == "0")
            {
                displayBox.Text = "9";
            }
            else
            {
                displayBox.Text += 9;
            }
        }

        private void dotButton_Click(object sender, EventArgs e)
        {
            if (operationCompleted)
            {
                displayLabel.Text = String.Empty;
                displayBox.Text = "0";
                operationCompleted = false;
            }

            if (Int64.TryParse(displayBox.Text, out long number))
            {
                displayBox.Text += ".";
            }
        }

        private void divideButton_Click(object sender, EventArgs e)
        {
            operationCompleted = false;
            Double.TryParse(displayBox.Text, out double result);
            FirstNumber = result;
            Operator = '/';
            displayBox.Text = "0";
            displayLabel.Text = FirstNumber.ToString() + " / ";
        }

        private void multiplyButton_Click(object sender, EventArgs e)
        {
            operationCompleted = false;
            Double.TryParse(displayBox.Text, out double result);
            FirstNumber = result;
            Operator = '*';
            displayBox.Text = "0";
            displayLabel.Text = FirstNumber.ToString() + " * ";
        }

        private void minusButton_Click(object sender, EventArgs e)
        {
            operationCompleted = false;
            Double.TryParse(displayBox.Text, out double result);
            FirstNumber = result;
            Operator = '-';
            displayBox.Text = "0";
            displayLabel.Text = FirstNumber.ToString() + " - ";
        }

        private void plusButton_Click(object sender, EventArgs e)
        {
            operationCompleted = false;
            Double.TryParse(displayBox.Text, out double result);
            FirstNumber = result;
            Operator = '+';
            displayBox.Text = "0";
            displayLabel.Text = FirstNumber.ToString() + " + ";
        }

        private void equalButton_Click(object sender, EventArgs e)
        {
            Double.TryParse(displayBox.Text, out double result);
            SecondNumber = result;

            switch (Operator)
            {
                case '+':
                    Result = FirstNumber + SecondNumber;
                    break;
                case '-':
                    Result = FirstNumber - SecondNumber;
                    break;
                case '*':
                    Result = FirstNumber * SecondNumber;
                    break;
                case '/':
                    if (SecondNumber == 0.0)
                    {
                        displayBox.Text = "DIV/Zero!";
                    }
                    else
                    {
                        Result = FirstNumber / SecondNumber;
                    }
                    break;
            }
            displayLabel.Text += SecondNumber.ToString() + " =";
            displayBox.Text = Result.ToString();
            operationCompleted = true;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            displayLabel.Text = String.Empty;
            displayBox.Text = "0";
            FirstNumber = 0.0;
            SecondNumber = 0.0;
            Result = 0.0;
            operationCompleted = false;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if (displayBox.Text.Length > 1)
            {
                displayBox.Text = displayBox.Text.Remove(displayBox.Text.Length - 1);
            }
            else
            {
                displayBox.Text = "0";
            }
        }

        private void invertButton_Click(object sender, EventArgs e)
        {
            Double.TryParse(displayBox.Text, out double result);
            result = 0 - result;
            displayBox.Text = result.ToString();
        }

        private void percentButton_Click(object sender, EventArgs e)
        {
            Double.TryParse(displayBox.Text, out double result);
            result = FirstNumber * result / 100;
            displayBox.Text = result.ToString();
        }
    }
}
