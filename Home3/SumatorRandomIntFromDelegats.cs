using System;

namespace Home3
{
    public delegate double MiddleValue(RandomValue[] randomValues);
    public delegate int RandomValue();

    public class SumatorRandomIntFromDelegats
    {
        private MiddleValue middleValue = (array) =>
        {
            int sum = 0;

            for (int i = 0; i < array.Length; i++)
                sum += array[i].Invoke();

            return Convert.ToDouble(sum / array.Length);
        };

        private RandomValue randomValue = () => { return new Random().Next(); };
        private RandomValue[] randomValues;

        public double GetMiddleValue()
        {
            return middleValue(randomValues);
        }

        public SumatorRandomIntFromDelegats(int amount)
        {
            if (amount <= 0)
                amount = 1;

            randomValues = new RandomValue[amount];

            for (int i = 0; i < randomValues.Length; i++)
                randomValues[i] = randomValue;
        }
    }
}
