using System;

namespace Home1
{
    public class Calculator<T, U>
         where T : struct, IFormattable, IConvertible
         where U : struct, IFormattable, IConvertible
    {

        public double Sum(T summand, U summand2)
        {
            return Convert.ToDouble(summand) + Convert.ToDouble(summand2);
        }

        public double Subtraction(T reduce, U subtracted)
        {
            return Convert.ToDouble(reduce) - Convert.ToDouble(subtracted);
        }

        public double Multiplication(T multiplier, U multiplier2)
        {
            return Convert.ToDouble(multiplier) * Convert.ToDouble(multiplier2);
        }

        public double Divide(T divisible, U divisor)
        {
            if (Convert.ToDouble(divisor) == 0)
                throw new ArithmeticException();
            else
                return Convert.ToDouble(divisible) / Convert.ToDouble(divisor);
        }
    }
}
