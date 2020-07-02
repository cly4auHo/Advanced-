using System;

namespace Home1
{
    public class BookMain
    {
        public static void Main(string[] args)
        {
            Book<int> bookInt = new Book<int>();
            Book<double> bookDouble = new Book<double>();

            bookInt.Name = "Art of War";
            bookInt.Price = 100;

            bookDouble.Name = "Code Complete";
            bookDouble.Price = 250.7;

            bookInt.Show();
            bookDouble.Show();

            Console.ReadKey();
        }   
    }
}
