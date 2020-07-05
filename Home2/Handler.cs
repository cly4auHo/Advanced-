using System;
using System.Collections.Generic;
using System.Linq;

namespace Home2
{
    class Handler
    {
        private SortedList<string, int> sortedList = new SortedList<string, int>();

        public SortedList<string, int> SortedList { get => sortedList; set => sortedList = value; }

        public Handler() { }

        public Handler(SortedList<string, int> sortedList)
        {
            this.sortedList = sortedList;
        }

        public void PrintAlphabeticalOrder()
        {
            sortedList.OrderBy(list => list.Key);

            foreach (var item in sortedList)
                Console.WriteLine(item);
        }

        public void PrintReverseAlphabeticalOrder()
        {
            SortedList<string, int> newList = new SortedList<string, int>(Comparer<string>.Create((x, y) => y.CompareTo(x)));
            var keys = sortedList.Keys;

            foreach (string key in keys)
                newList.Add(key, sortedList[key]);

            //sortedList.Reverse(); don`t work

            foreach (var item in sortedList)
                Console.WriteLine(item);
        }
    }
}
