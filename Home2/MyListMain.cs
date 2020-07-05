using System;

namespace Home2
{
    public class MyListMain
    {
        public static void Main(string[] args)
        {
            IMyList<int> myList = new MyList<int>();

            for (int i = 0; i < 20; i++)
                myList.Add(i * i);

            for (int i = 0; i < myList.Count; i++)
                Console.WriteLine(myList[i]);

            Console.WriteLine(myList.Contains(0));
        }
    }
}
