using System;
using System.Reflection;

namespace Home6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Assembly assembly = Assembly.Load("Convertor");
                Type type = assembly.GetType("Convertor.ConvertorTemperature");
                MethodInfo methodAcceleration = type.GetMethod("CelsiusToFahrenheit");
                double? t = methodAcceleration.Invoke(Activator.CreateInstance(type), new object[] { 70.6 }) as double?;
                Console.WriteLine(t);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}
