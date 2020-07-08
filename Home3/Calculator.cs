using System;

namespace Home3
{
    public delegate double Calculus(double a, double b);

    public class Calculator
    {
        public double Calculate(double a, double b, Operators operation)
        {
            Calculus calculus;

            switch (operation)
            {
                case Operators.SUM:
                    calculus = (a1, b1) => a1 + b1;
                    return calculus(a, b);
                case Operators.SUBSTRACT:
                    calculus = (a1, b1) => a1 - b1;
                    return calculus(a, b);
                case Operators.MULTIPLIES:
                    calculus = (a1, b1) => a1 * b1;
                    return calculus(a, b);
                case Operators.DIVIDE:
                    calculus = (a1, b1) =>
                    {
                        try
                        {
                            return a1 / b1;
                        }
                        catch (ArithmeticException e)
                        {
                            Console.WriteLine(e.Message);
                            return default;
                        }
                    };

                    return calculus(a, b);
                default:
                    return default;
            }
        }
    }

    public enum Operators
    {
        SUM,
        SUBSTRACT,
        MULTIPLIES,
        DIVIDE
    }
}
