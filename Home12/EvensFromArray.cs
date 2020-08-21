using System.Linq;

namespace Home12
{
    public class EvensFromArray
    {
        public int[] GetEvenValues(int[] array)
        {           
            return array.AsParallel().Where(x => x % 2 == 0).ToArray();
        }      
    }
}
