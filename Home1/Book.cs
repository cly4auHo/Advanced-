using System;

namespace Home1
{
    public class Book<T> where T : struct, IFormattable, IConvertible
    {
        private string name = "DEFAULT_NAME";
        private T price;

        public string Name
        {
            get => name;

            set
            {
                name = value != null ? value : "DEFAULT_NAME";
            }
        }

        public T Price { get => price; set => price = value; }

        public void Show()
        {
            Console.WriteLine("Name is " + name + " Price is " + price);
        }

        public Book() { }
    }
}
