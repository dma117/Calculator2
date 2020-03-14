using System;


namespace Calculator.Model
{
    public class Calc
    {
        public string LeftNumber;
        public string RightNumber;
        public string Operation;
        public double MemoryNumber;

        public Calc()
        {
            LeftNumber = "0";
            RightNumber = "";
            Operation = "";
            MemoryNumber = 0;
        }

        public string CountExpressionResult()
        {
            double firstNumber = double.Parse(LeftNumber);
            double secondNumber = double.Parse(RightNumber);

            if (Operation == "/" && secondNumber == 0)
            {
                return "Error: numbers can not be divided by zero";
            }

            switch (Operation)
            {
                case "-":
                    firstNumber -= secondNumber;
                    break;
                case "+":
                    firstNumber += secondNumber;
                    break;
                case "x":
                    firstNumber = firstNumber * secondNumber + 0;
                    break;
                case "/":
                    firstNumber /= secondNumber;
                    break;
            }

            return Math.Round(firstNumber, 10).ToString();
        }
    }
}