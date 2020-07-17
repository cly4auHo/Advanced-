using System;

namespace Home4
{
    public class Calculator
    {
        private const string ExceptionMessage = "Bad numbers";
        private const string DivideByZeroMessage = "Divisor must be not 0";

        public dynamic Sum(dynamic summand, dynamic summand2)
        {
            try
            {
                return summand + summand2;
            }
            catch
            {
                return ExceptionMessage;
            }
        }

        public dynamic Subtraction(dynamic reduce, dynamic subtracted)
        {
            try
            {
                return reduce - subtracted;
            }
            catch
            {
                return ExceptionMessage;
            }
        }

        public dynamic Multiplication(dynamic multiplier, dynamic multiplier2)
        {
            try
            {
                return multiplier * multiplier2;
            }
            catch
            {
                return ExceptionMessage;
            }
        }

        public dynamic Divide(dynamic divisible, dynamic divisor)
        {
            try
            {
                return divisible / divisor;
            }
            catch (DivideByZeroException)
            {
                return DivideByZeroMessage;
            }
            catch
            {
                return ExceptionMessage;
            }
        }
    }
}
