namespace Convertor
{
    public class ConvertorTemperature
    {
        private const double offsetCelsiusKelvin = 273.15;
        private const double offsetCelsiusFahrenheit = 32;
        private const double coefficientCelsiusFahrenheit = 1.8;

        private const double minValueFahrenheit = -459.67;
        private const double minValueCelsius = -273.15;
        private const double minValueKelvin = 0;

        //K = C - 273.15
        public double CelsiusToKelvin(double temperatureInCelsius)
        {
            if (temperatureInCelsius < minValueCelsius)
                temperatureInCelsius = minValueCelsius;

            return temperatureInCelsius - offsetCelsiusKelvin;
        }

        //C = K + 273.15
        public double KelvinToCelsius(double temperatureInKelvin)
        {
            if (temperatureInKelvin < minValueKelvin)
                temperatureInKelvin = minValueKelvin;

            return temperatureInKelvin + offsetCelsiusKelvin;
        }

        //F = (K - 273.15) * 1.8 + 32
        public double KelvinToFahrenheit(double temperatureInKelvin)
        {
            if (temperatureInKelvin < minValueKelvin)
                temperatureInKelvin = minValueKelvin;

            return (temperatureInKelvin - offsetCelsiusKelvin) * coefficientCelsiusFahrenheit + offsetCelsiusFahrenheit;
        }

        //K = (F - 32) / 1.8 + 273.15
        public double FahrenheitToKelvin(double temperatureInFahrenheit)
        {
            if (temperatureInFahrenheit < minValueFahrenheit)
                temperatureInFahrenheit = minValueFahrenheit;

            return (temperatureInFahrenheit - offsetCelsiusFahrenheit) / coefficientCelsiusFahrenheit + offsetCelsiusKelvin;
        }

        //F = C * 1.8 + 32
        public double CelsiusToFahrenheit(double temperatureInCelsius)
        {
            if (temperatureInCelsius < minValueCelsius)
                temperatureInCelsius = minValueCelsius;

            return temperatureInCelsius * coefficientCelsiusFahrenheit + offsetCelsiusFahrenheit;
        }

        //C = (F - 32) / 1.8
        public double FahrenheitToCelsius(double temperatureInFahrenheit)
        {
            if (temperatureInFahrenheit < minValueFahrenheit)
                temperatureInFahrenheit = minValueFahrenheit;

            return (temperatureInFahrenheit - offsetCelsiusFahrenheit) / coefficientCelsiusFahrenheit;
        }
    }
}
