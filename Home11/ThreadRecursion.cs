using System.Threading;

namespace Home11
{
    public class ThreadRecursion
    {
        public void Run()
        {
            new Thread(Run).Start();
            Run();
        }
    }
}
