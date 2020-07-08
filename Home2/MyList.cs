using System;
using System.Linq;

namespace Home2
{
    public class MyList<T> : IMyList<T>
    {
        private T[] array;

        public MyList()
        {
            array = new T[0];
        }

        public T this[int index]
        {
            get
            {
                try
                {
                    return array[index];
                }
                catch(ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                    return default;
                }
            }
        }

        public int Count => array.Length;

        public void Add(T item)
        {
            T[] newArray = new T[array.Length + 1];

            for (int i = 0; i < array.Length; i++)
                newArray[i] = array[i];

            newArray[array.Length] = item;
            array = newArray;
        }

        public void Clear()
        {
            array = new T[0];
        }

        public bool Contains(T item)
        {
            return array.Contains(item);
        }
    }

    public static class ExtensionClass
    {
        public static T[] GetArray<T>(this MyList<T> list)
        {
            T[] array = new T[list.Count];

            for (int i = 0; i < array.Length; i++)
                array[i] = list[i];

            return array;
        }
    }
}
