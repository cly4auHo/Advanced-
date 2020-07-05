namespace Home2
{
    public interface IMyList<T>
    {
        T this[int index] { get; }

        int Count { get; }

        void Add(T a);

        void Clear();

        bool Contains(T item);
    }
}
