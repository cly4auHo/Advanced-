namespace Home1
{
    public class MyClass<T> where T : class, new()
    {
        #region Singleton

        private static MyClass<T> instance;

        public static MyClass<T> Instance
        {
            get
            {
                if (instance == null)
                    instance = new MyClass<T>();

                return instance;
            }
        }

        private MyClass() { }

        #endregion

        public static T FactoryMethod()
        {
            return new T() ;
        }
    }
}
