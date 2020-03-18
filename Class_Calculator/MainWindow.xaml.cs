using System;
using System.Windows;
using System.Windows.Controls;
using Class_Calculator.Model;

namespace Class_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private readonly Calc myCalc = new Calc();

        public string Result;
        
        private void Button_Click(string clickedButton)
        {
            bool correct = Int32.TryParse(clickedButton, out _);

            if (clickedButton == "C")
            {
                BlockExpression.Text = myCalc.OperationClean();
            }
            else if (clickedButton == "B")
            {
                BlockExpression.Text = myCalc.OperationBackspace(Result);
            }
            else if (clickedButton == "CE")
            {
                BlockExpression.Text = myCalc.OperationCleanEntry();
            }
            else if (clickedButton.Contains("M"))
            {
                if (clickedButton == "MR")
                {
                    BlockExpression.Text = myCalc.OperationMemory(clickedButton, Result);
                }
                else
                {
                    BlockMemory.Text = myCalc.OperationMemory(clickedButton, Result);
                }
            }
            else if (clickedButton == "+/-")
            {
                BlockExpression.Text = myCalc.OperationSwitchSign();
            }
            else if (clickedButton == "=")
            {
                BlockExpression.Text = myCalc.ParseEqualsSign(clickedButton, ref Result);
            }
            else
            {
                if (correct || clickedButton == ",")
                {
                    BlockExpression.Text = myCalc.ParseNumbers(clickedButton, ref Result);;
                }
                else
                {
                    BlockExpression.Text = myCalc.ParseMathOperations(clickedButton, ref Result);
                }
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;
            string itemValue = menuItem.Header.ToString();

            if (itemValue == "Exit")
            {
                Close();
            }
            if (itemValue == "Info")
            {
                MessageBox.Show("Calculator. It can sum, subtract, multiply and divide numbers.\n" +
                    "Made by Donskaya Maria. 2020");
            }
        }

        #region AddButtonHandler

         private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            Button_Click("C");
        }

        private void ButtonSeven_Click(object sender, RoutedEventArgs e)
        {
            Button_Click("7");
        }

        private void ButtonTwo_Click(object sender, RoutedEventArgs e)
        {
            Button_Click("2");
        }

        private void ButtonDivide_Click(object sender, RoutedEventArgs e)
        {
            Button_Click("/");
        }

        private void ButtonNine_Click(object sender, RoutedEventArgs e)
        {
            Button_Click("9");
        }

        private void ButtonSummurize_Click(object sender, RoutedEventArgs e)
        {
            Button_Click("+");
        }

        private void ButtonMinus_Click(object sender, RoutedEventArgs e)
        {
            Button_Click("-");
        }

        private void ButtonSix_Click(object sender, RoutedEventArgs e)
        {
            Button_Click("6");
        }

        private void ButtonX_Click(object sender, RoutedEventArgs e)
        {
            Button_Click("x");
        }

        private void ButtonThree_Click(object sender, RoutedEventArgs e)
        {
            Button_Click("3");
        }

        private void ButtonEight_Click(object sender, RoutedEventArgs e)
        {
            Button_Click("8");
        }

        private void ButtonFive_Click(object sender, RoutedEventArgs e)
        {
            Button_Click("5");
        }

        private void ButtonOne_Click(object sender, RoutedEventArgs e)
        {
            Button_Click("1");
        }

        private void ButtonZero_Click(object sender, RoutedEventArgs e)
        {
            Button_Click("0");
        }

        private void ButtonEqual_Click(object sender, RoutedEventArgs e)
        {
            Button_Click("=");
        }

        private void ButtonFour_Click(object sender, RoutedEventArgs e)
        {
            Button_Click("4");
        }

        private void ButtonDot_Click(object sender, RoutedEventArgs e)
        {
            Button_Click(",");
        }

        private void ButtonBackspace_Click(object sender, RoutedEventArgs e)
        {
            Button_Click("B");
        }

        private void ButtonCE_Click(object sender, RoutedEventArgs e)
        {
            Button_Click("CE");
        }

        private void ButtonMPlus_Click(object sender, RoutedEventArgs e)
        {
            Button_Click("M+");
        }

        private void ButtonMMinus_Click(object sender, RoutedEventArgs e)
        {
            Button_Click("M-");
        }

        private void ButtonMC_Click(object sender, RoutedEventArgs e)
        {
            Button_Click("MC");
        }

        private void ButtonMR_Click(object sender, RoutedEventArgs e)
        {
            Button_Click("MR");
        }

        private void ButtonMS_Click(object sender, RoutedEventArgs e)
        {
            Button_Click("MS");
        }

        private void ButtonPlusMinus_Click(object sender, RoutedEventArgs e)
        {
            Button_Click("+/-");
        }

        #endregion
    }
}