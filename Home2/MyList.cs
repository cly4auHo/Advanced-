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
                if (index < 0 || index >= array.Length)
                    throw new ArgumentOutOfRangeException();
                else
                    return array[index];
            }
        }

        public int Count => array.Length;

        public void Add(T a)
        {
            T[] newArray = new T[array.Length + 1];

            for (int i = 0; i < array.Length; i++)
                newArray[i] = array[i];

            newArray[newArray.Length - 1] = a;
            array = newArray;
        }

        public void Clear()
        {
            array = new T[0];
        }

        public bool Contains(T item)
        {
            return array.Any(x => x.Equals(item));
        }

        //public static T[] GetArray<T>(this MyList<T> list)
        //{

        //    return null;
        //}
    }
}
