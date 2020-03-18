using System;
using System.Linq;
using Microsoft.VisualBasic;

namespace Class_Calculator.Model
{
    public class Calc
    {
        public string LeftNumber;
        public string RightNumber;
        public string Operation;
        private string memoryNumber;
        private bool clickedM;
        private const string Error = "Error: numbers can not be divided by zero";

        public Calc()
        {
            LeftNumber = "0";
            RightNumber = "";
            Operation = "";
            memoryNumber = "0";
            clickedM = false;
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
        
        public void ClearVariables()
        {
            LeftNumber = "0";
            RightNumber = "";
            Operation = "";
        }

        public string OperationBackspace(string result)
        {
            if (Operation == "" && Operation != "=")
            {
                if (LeftNumber != result)
                {
                    ParseOperationB(ref LeftNumber);
                }
            }
            else
            {
                if (RightNumber != "")
                {
                    ParseOperationB(ref RightNumber);
                }
            }
            if (Operation == "=")
            {
                return LeftNumber;
            }
            return LeftNumber + Operation + RightNumber;
        }
        
        public void ParseOperationB(ref string number)
        {
            if (number.Length == 1)
            {
                number = "0";
            }
            else
            {
                number = number[..^1];
            }
        }

        public string OperationClean()
        {
            ClearVariables();
            return LeftNumber;
        }

        public string OperationCleanEntry()
        {
            if (Operation == "" || Operation == "=")
            {
                ClearVariables();
            }
            else
            {
                RightNumber = "0";
            }
        
            return LeftNumber + Operation + RightNumber;
        }
        
        public string OperationSwitchSign()
        {
            if (Operation == "" || Operation == "=")
            {
                AddPlusMinus(ref LeftNumber);
                return LeftNumber;
            }
            AddPlusMinus(ref RightNumber);
            return LeftNumber + Operation + RightNumber;
        }
        
        public string ParseEqualsSign(string signFromButton, ref string result)
        {
            if (result == Error)
            {
                result = "";
            }
            if (RightNumber == "")
            {
                if (LeftNumber[^1..] == ",")
                {
                    LeftNumber = LeftNumber[..^1];
                }

                Operation = "=";
                return LeftNumber;
            }
            result = CountExpressionResult();
            return GetExpressionResult(signFromButton, ref result);
        }

        public string ParseMathOperations(string signFromButton, ref string result)
        {
            if (result == Error)
            {
                result = "";
            }
            if (RightNumber == "")
            {
                Operation = signFromButton;
                return LeftNumber + Operation;
            }
            result = CountExpressionResult();
            return GetExpressionResult(signFromButton, ref result);
        }

        public string ParseNumbers(string numberFromButton, ref string result)
        {
            if (result == Error)
            {
                result = "";
            }
            if (Operation == "=")
            {
                ClearVariables();
            }
            if (Operation == "")
            {
                GetNumbers(numberFromButton, ref LeftNumber);
            }
            else
            {
                GetNumbers(numberFromButton, ref RightNumber);
            }

            return LeftNumber + Operation + RightNumber;
        }
        
        private void GetNumbers(string signFromButton, ref string number)
        {
            if (signFromButton == ",")
            {
                AnalyzeDoubleNumbers(signFromButton, ref number);
            }
            else
            {
                FindNumbers(signFromButton, ref number);
            }
        }
        
        private void FindNumbers(string numberFromButton, ref string number)
        {
            if (number.Length > 12) return;
            if (numberFromButton == "0" && (number == "" || number == "0"))
            {
                number = "0";
            }
            else
            {
                if (number == "0")
                {
                    number = "";
                }
                
                number += numberFromButton;
            }
        }

        private void AnalyzeDoubleNumbers(string signFromButton, ref string number)
        {
            if (number.Contains(",") || number.Length > 12) return;
            if (number == "")
            {
                number = "0,";
            }
            else
            {
                number += signFromButton;
            }
        }
        private string GetExpressionResult(string signFromButton, ref string result)
        {
            ClearVariables();

            if (result == Error)
            {
                LeftNumber = "0";
            }
            else
            {
                LeftNumber = result;
                Operation = signFromButton;
            }

            if (signFromButton == "=" || result == Error)
            {
                return result;
            }
            return result + Operation;
        }
        
        private void AddPlusMinus(ref string number)
        {
            if (number == "0" || number == "") return;
            if (number.Contains("-"))
            {
                number = number[1..];
            }
            else
            {
                number = "-" + number;
            }
        }

        public string OperationMemory(string signFromButton, string result)
        {
            string text;
            
            if (result == Error)
            {
                if (!clickedM)
                {
                    if (signFromButton == "MR")
                    {
                        return Error;
                    }
                    return "";
                }
                if (signFromButton != "MC")
                {
                    return memoryNumber;
                }
            }
            
            if (Operation == "" || Operation == "=" || RightNumber == "" && signFromButton != "MR")
            {
                text = ParseMemorySign(signFromButton, ref LeftNumber);
            }
            else
            {
                text = ParseMemorySign(signFromButton, ref RightNumber);
                if (signFromButton == "MR")
                {
                    text = LeftNumber + Operation + RightNumber;
                }
            }

            return text;
        }
        
        private string ParseMemorySign(string signFromButton, ref string number)
        {
            switch (signFromButton)
            {
                case "MS":
                    clickedM = true;
                    memoryNumber = number;
                    break;
                case "M+":
                    clickedM = true;
                    memoryNumber = Math.Round(double.Parse(memoryNumber) + double.Parse(number), 11).ToString();
                    break;
                case "M-":
                    clickedM = true;
                    memoryNumber = Math.Round(double.Parse(memoryNumber) - double.Parse(number), 11).ToString();
                    break;
                case "MR":
                    if (clickedM)
                    {
                        number = memoryNumber;
                        if (Operation == "=")
                        {
                            Operation = "";
                        }
                    }
                    break;
                case "MC":
                    clickedM = false;
                    memoryNumber = "0";
                    break;
            }
            
            if (signFromButton.Contains("MC"))
            {
                return "";
            }
            if (clickedM)
            {
                return memoryNumber;
            }
            return number;
        }
    }
}