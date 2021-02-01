using System;
using System.Collections.Generic;
using System.Text;

namespace Calci
{
    public static class Operator
    {
        public static double Calculate(double first, double second, string Operator)
        {
            double result = 0;
            switch(Operator)
            {
                case "+":
                    result = first + second;
                    break;

                case "-":
                    result = first - second;
                    break;

                case "×":
                    result = first * second;
                    break;

                case "÷":
                    result = first / second;
                    break;

                case "%":
                    result = first / 100;
                    break;
            }
            return result;
        }
    }
}
