using System.Threading;
using System.Threading.Tasks;

namespace Home12
{
    public class Program
    {
        private static Thread thread1;
        private static Thread thread2;
        private static Thread main;

        public static void Main(string[] args)
        {
            main = Thread.CurrentThread;
            thread1 = new Thread(ThreadMethod1);
            thread2 = new Thread(ThreadMethod2);

            Parallel.Invoke(Method1, Method2);
        }

        private static void Method1()
        {
            thread1.Start();
            main.Join();
        }

        private static void Method2()
        {
            thread2.Start();
            main.Join();
        }

        private static void ThreadMethod1()
        {

        }

        private static void ThreadMethod2()
        {

        }
    }
}
