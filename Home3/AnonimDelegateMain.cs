using System;

namespace Home3
{
    public delegate int MyDelegate(int a, int b, int c);

    public class AnonimDelegateMain
    {
        public static void Main(string[] args)
        {
            MyDelegate myDelegate = delegate (int a, int b, int c)
            {
                return (a + b + c) / 3;
            };

            Console.WriteLine(myDelegate(1, 2, 3));
            Console.ReadKey();
        }
    }
}
