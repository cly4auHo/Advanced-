namespace Home4
{
    public class FindFirstAndLastMain
    {
        private static void FirstAndLastArray(int[] array, out int first, out int last)
        {
            first = -1;
            last = 0;

            if (array != null)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] >= 0)
                    {
                        if (first == -1)
                            first = array[i];
                    }
                    else
                        last = array[i];
                }
            }
        }
    }
}
